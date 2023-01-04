using Epam.TestAutomation.Core.DriverCreator;
using Epam.TestAutomation.Core.Helper;
using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Utilities.Logger;
using Epam.TestAutomation.Core.ScreenShotMaker;
using Epam.TestAutomation.Pages.PageObjects.Pages;

namespace Epam.TestAutomation.Tests;

public abstract class BaseTest
{
    protected MainPage MainPage { get; set; }

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        MyLogger.InitLogger("logs_", UiTestSettings.LogsPath);
    }

    [SetUp]
    public void SetUp()
    {
        MyLogger.Info("Test execution is started.");
        Browser.Driver.GotToWebPageUrl(UiTestSettings.ApplicationUrl);
        Waiter.WaitForPageLoading();

        MainPage = new MainPage();
    }

    [TearDown]
    public void TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed)
        {
            MyLogger.Info($"Test '{TestContext.CurrentContext.Test.MethodName}' is passed.");
        }

        if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            MyLogger.Info($"Test '{TestContext.CurrentContext.Test.MethodName}' is failed.");
            ScreenshotMaker.SaveScreenshot(TestContext.CurrentContext.Test.MethodName, UiTestSettings.ScreenshotPath);
        }

        MyLogger.Info($"'{TestContext.CurrentContext.Test.ClassName}' execution is finished.");
        Browser.Driver.QuitBrowser();
    }
}