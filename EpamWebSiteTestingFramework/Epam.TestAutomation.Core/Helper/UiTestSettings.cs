using Epam.TestAutomation.Core.Enums;
using Epam.TestAutomation.TestData;
using Epam.TestAutomation.Utilities.EnumParser;

namespace Epam.TestAutomation.Core.Helper;

public static class UiTestSettings
{
    public static string ScreenshotPath => TestInfo.ScreenshotPath;
    public static string LogsPath => TestInfo.LogsPath;
    public static TimeSpan WebDriverTimeOut => TimeSpan.FromSeconds(TestInfo.WebDriverTimeOut);
    public static BrowserType GetCurrentBrowser => Browser;
    public static string ApplicationUrl => TestInfo.ApplicationUrl;
    public static string JobListingUrl => TestInfo.JobListingUrl;

    public static string JobListingUrl => TestInfo.JobListingUrl;
    private static BrowserType Browser => EnumParser.GetEnumValueByDescription<BrowserType>("DefaultBrowser");
}