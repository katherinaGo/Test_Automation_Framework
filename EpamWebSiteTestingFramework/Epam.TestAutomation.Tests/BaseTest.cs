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
    public void LoggerSetUp()
    {
        MyLogger.Info($"Test '{TestContext.CurrentContext.Test.MethodName}' execution is started.");
    }

    [SetUp]
    public void DriverSetUp()
    {
        Browser.Driver.GotToWebPageUrl(UiTestSettings.ApplicationUrl);
        Waiter.WaitForPageLoading();
    }

    [SetUp]
    public void PagesSetUp()
    {
        MainPage = new MainPage();
    }

    [TearDown]
    public void DriverTearDown()
    {
        Browser.Driver.QuitBrowser();
    }

    [TearDown]
    public void LoggerTearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed)
        {
            MyLogger.Info($"Test '{TestContext.CurrentContext.Test.MethodName}' is passed.");
        }

        else if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            MyLogger.Info($"Test '{TestContext.CurrentContext.Test.MethodName}' is failed.");
            ScreenshotMaker.SaveScreenshot(TestContext.CurrentContext.Test.MethodName, UiTestSettings.ScreenshotPath);
        }
        else

        {
            MyLogger.Error($"Something went wrong with test execution. {TestContext.CurrentContext.Result.StackTrace}");
            ScreenshotMaker.SaveScreenshot(TestContext.CurrentContext.Test.MethodName, UiTestSettings.ScreenshotPath);
        }

        MyLogger.Info($"'{TestContext.CurrentContext.Test.ClassName}' execution is finished.");
    }
}