using System.Text.Json.Serialization;

namespace Epam.TestAutomation.TestData;

public class TestInfo
{
    [JsonPropertyName("applicationUrl")] public string ApplicationUrl { get; set; }

    [JsonPropertyName("screenshotPath")] public string ScreenshotPath { get; set; }

    [JsonPropertyName("screenshotPath2")] public string ScreenshotPath2 { get; set; }
    [JsonPropertyName("logsPath")] public string LogsPath { get; set; }

    [JsonPropertyName("webDriverTimeOut")] public int WebDriverTimeOut { get; set; }

    [JsonPropertyName("defaultTimeOut")] public int DefaultTimeOut { get; set; }
}