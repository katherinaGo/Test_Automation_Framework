using Microsoft.Extensions.Configuration;

namespace Epam.TestAutomation.TestData;

public static class TestInfo
{
    public static readonly string ApplicationUrl = SetAppSettingsFromJson("applicationUrl")!;

    public static readonly string ScreenshotPath = SetAppSettingsFromJson("screenshotPath")!;

    public static readonly string LogsPath = SetAppSettingsFromJson("logsPath")!;

    public static readonly double WebDriverTimeOut =
        double.Parse(SetAppSettingsFromJson("webDriverTimeOut")!);

    public static readonly string JobListingUrl = SetAppSettingsFromJson("jobListingUrl")!;

    private static string? SetAppSettingsFromJson(string keyName)
    {
        return new ConfigurationBuilder()
            .AddJsonFile(Directory.GetCurrentDirectory() + "/appsettings.json")
            .Build()
            .GetSection(keyName).Value;
    }
}