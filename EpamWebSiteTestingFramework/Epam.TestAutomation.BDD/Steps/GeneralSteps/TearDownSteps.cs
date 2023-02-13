using Epam.TestAutomation.Core.DriverCreator;
using Epam.TestAutomation.Core.Helper;
using Epam.TestAutomation.Core.ScreenShotMaker;
using Epam.TestAutomation.Utilities.Logger;
using TechTalk.SpecFlow;

namespace Epam.TestAutomation.BDD.Steps.GeneralSteps;

[Binding]
public class TearDownSteps
{
    [AfterScenario]
    public static void CleanTest()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed)
        {
            MyLogger.Info($"Test '{TestContext.CurrentContext.Test.MethodName}' is passed.");
        }

        if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            MyLogger.Info($"Test '{TestContext.CurrentContext.Test.MethodName}' is failed.");
            ScreenshotMaker.SaveScreenshot(TestContext.CurrentContext.Test.MethodName,
                UiTestSettings.ScreenshotPath);
        }
        else
        {
            MyLogger.Error(
                $"Something went wrong with test execution. {TestContext.CurrentContext.Result.StackTrace}");
            ScreenshotMaker.SaveScreenshot(TestContext.CurrentContext.Test.MethodName,
                UiTestSettings.ScreenshotPath);
        }

        MyLogger.Info($"'{TestContext.CurrentContext.Test.ClassName}' execution is finished.");
        Browser.Driver.QuitBrowser();
    }
}