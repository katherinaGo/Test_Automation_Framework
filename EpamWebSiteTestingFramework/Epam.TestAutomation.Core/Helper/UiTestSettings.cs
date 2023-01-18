using Epam.TestAutomation.Core.Enums;
using Epam.TestAutomation.TestData;
using Epam.TestAutomation.Utilities.EnumParser;
using Epam.TestAutomation.Utilities.JsonParser;

namespace Epam.TestAutomation.Core.Helper;

public static class UiTestSettings
{
    private static BrowserType Browser => EnumParser.GetEnumValueByDescription<BrowserType>("DefaultBrowser");
    private static ProjectSetUpInfo ProjectSetUpInfo => GetTestInfoFromJson();

    private static ProjectSetUpInfo GetTestInfoFromJson() => JsonParser.Deserialize<ProjectSetUpInfo>(
        "/Users/kate/RiderProjects/Test_Automation_Framework/EpamWebSiteTestingFramework/Epam.TestAutomation.TestData/projectsetup.json"
    );

    public static string ScreenshotPath => ProjectSetUpInfo.ScreenshotPath;
    public static string LogsPath => ProjectSetUpInfo.LogsPath;
    public static TimeSpan WebDriverTimeOut => TimeSpan.FromSeconds(ProjectSetUpInfo.WebDriverTimeOut);
    public static BrowserType GetCurrentBrowser => Browser;

    public static string ApplicationUrl => ProjectSetUpInfo.ApplicationUrl;
    public static string JobListingUrl => ProjectSetUpInfo.JobListingUrl;
}