using Epam.TestAutomation.Core.Helper;
using Epam.TestAutomation.Utilities.Logger;
using TechTalk.SpecFlow;

namespace Epam.TestAutomation.BDD.Steps.GeneralSteps;

[Binding]
public class SetupSteps
{
    [BeforeFeature(Order = 1)]
    public static void OneTimeSetUp()
    {
        MyLogger.InitLogger("logs_", UiTestSettings.LogsPath);
    }

    [BeforeScenario]
    public static void BeforeTest()
    {
        MyLogger.Info("BDD Test begins.");
    }
}