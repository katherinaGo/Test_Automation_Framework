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
        MyLogger.InitLogger("logs_", UiTestSettings.LogsPath);
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
            MyLogger.Info($"Test '{TestContext.CurrentContext.Test.MethodName}' is failed.");
            ScreenshotMaker.SaveScreenshot(TestContext.CurrentContext.Test.MethodName, UiTestSettings.ScreenshotPath);
        }

        MyLogger.Info("Test execution is finished.");
        DriverFactory.Driver.Quit();
    }
}