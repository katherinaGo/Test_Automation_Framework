using Newtonsoft.Json;

namespace Epam.TestAutomation.TestData;

public class ProjectSetUpInfo
{
    [JsonProperty("applicationUrl")] public string? ApplicationUrl { get; set; }
    [JsonProperty("jobListingUrl")] public string? JobListingUrl { get; set; }

    [JsonProperty("screenshotPath")] public string? ScreenshotPath { get; set; }

    [JsonProperty("logsPath")] public string? LogsPath { get; set; }

    [JsonProperty("webDriverTimeOut")] public int WebDriverTimeOut { get; set; }
}