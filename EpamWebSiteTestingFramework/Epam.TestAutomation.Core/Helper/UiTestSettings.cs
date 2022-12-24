using Epam.TestAutomation.Core.Enums;
using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.TestData;
using Epam.TestAutomation.Utilities.JsonParser;

namespace Epam.TestAutomation.Core.Helper;

public static class UiTestSettings
{
    private static TestInfo TestInfo { get; set; }

    public static BrowserType Browser => EnumUtils.GetEnumValueByDescription<BrowserType>("DefaultBrowser");

    public static string ScreenshotPath => TestInfo.ScreenshotPath;

    public static string LogsPath => TestInfo.LogsPath;

    public static TimeSpan WebDriverTimeOut => TimeSpan.FromSeconds(TestInfo.WebDriverTimeOut);

    public static TimeSpan DefaultTimeOut => TimeSpan.FromSeconds(TestInfo.DefaultTimeOut);

    // TODO refactor method
    public static string ApplicationUrl()
    {
        GetTestInfo();
        return TestInfo.ApplicationUrl;
    }

    private static TestInfo GetTestInfo()
    {
        var json =
            File.ReadAllText(
                "/Users/kate/RiderProjects/Test_Automation_Framework/EpamWebSiteTestingFramework/Epam.TestAutomation.TestData/testdata.json");
        TestInfo = JsonParser.DeserializeJsonToObject<TestInfo>(json);
        return TestInfo;
    }
}