using System.Reflection;
using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Helper;
using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Utilities.Logger;
using Epam.TestAutomation.Core.ScreenShotMaker;

namespace Epam.TestAutomation.Tests;

public class BaseTest
{
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        MyLogger.InitLogger("logger", UiTestSettings.LogsPath);
    }

    [SetUp]
    public void SetUp()
    {
        MyLogger.Info("Test execution is started.");
        DriverFactory.Driver.GotToUrl(UiTestSettings.ApplicationUrl());
        Waiter.WaitForPageLoading();
    }

    [TearDown]
    public void TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            MyLogger.Info($"Test executions is failed in '{MethodBase.GetCurrentMethod()}'");
            ScreenshotMaker.SaveScreenshot(MethodBase.GetCurrentMethod()?.Name!, UiTestSettings.ScreenshotPath);
            Path.Combine(UiTestSettings.ScreenshotPath, UiTestSettings.ScreenshotPath2);
        }

        MyLogger.Info("Test execution is finished.");
        DriverFactory.Driver.Quit();
    }
}