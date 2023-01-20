using Epam.TestAutomation.Core.Enums;
using Epam.TestAutomation.TestData;
using Epam.TestAutomation.Utilities.EnumParser;
using Epam.TestAutomation.Utilities.JsonParser;
using NUnit.Framework;

namespace Epam.TestAutomation.Core.Helper;

public static class UiTestSettings
{
    public static string ScreenshotPath => TestInfo.ScreenshotPath;
    public static string LogsPath => TestInfo.LogsPath;
    public static TimeSpan WebDriverTimeOut => TimeSpan.FromSeconds(TestInfo.WebDriverTimeOut);
    public static BrowserType GetCurrentBrowser => Browser;

    public static string ApplicationUrl => TestInfo.ApplicationUrl;
    private static BrowserType Browser => EnumParser.GetEnumValueByDescription<BrowserType>("DefaultBrowser");
    private static TestInfo TestInfo => GetTestInfoFromJson();

    private static TestInfo GetTestInfoFromJson()
    {
        var json = File.ReadAllText(
            Path.Combine(Directory.GetCurrentDirectory(),
                TestContext.Parameters.Get("Epam.TestAutomation.TestData/testdata.json")));
        return JsonParser.DeserializeJsonToObject<TestInfo>(json);
    }
}