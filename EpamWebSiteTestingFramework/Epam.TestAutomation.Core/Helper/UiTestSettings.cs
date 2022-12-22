using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Utilities;

namespace Epam.TestAutomation.Core.Helper;

public static class UiTestSettings
{
    public static readonly BrowserType Browser =
        AppUtils.ParseEnum<BrowserType>(TestSettings.GetConfigurationValue("Browser") ?? "undefind");

    public static readonly TimeSpan WebDriverTimeOut =
        TimeSpan.FromSeconds(int.Parse(TestSettings.GetConfigurationValue("WebDriverTimeOut") ?? "0"));

    public static readonly TimeSpan WaitElementTimeOut =
        TimeSpan.FromSeconds(int.Parse(TestSettings.GetConfigurationValue("WaitElementTimeOut") ?? "0"));

    public static readonly string ScreenShotPath = Path.Combine(Directory.GetCurrentDirectory(),
        TestSettings.GetConfigurationValue("ScreenshotPath") ?? string.Empty);
}