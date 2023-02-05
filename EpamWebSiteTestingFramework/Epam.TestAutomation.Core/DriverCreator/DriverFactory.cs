using Epam.TestAutomation.Core.Enums;
using Epam.TestAutomation.Core.Helper;
using Epam.TestAutomation.Utilities.Logger;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;

namespace Epam.TestAutomation.Core.DriverCreator;

public static class DriverFactory
{
    private static IWebDriver? _driver;
    private static BrowserType _currentBrowser;

    internal static void DestroyWebBrowser()
    {
        _driver = null;
    }

    public static IWebDriver GetWebBrowser()
    {
        try
        {
            if (_driver == null)
            {
                _currentBrowser = UiTestSettings.GetCurrentBrowser;
                switch (_currentBrowser)
                {
                    case BrowserType.Chrome:
                        _driver = GetChromeConfiguredBrowser();
                        break;
                    case BrowserType.Safari:
                        _driver = GetSafariConfiguredBrowser();
                        break;
                    default:
                        _driver = GetChromeConfiguredBrowser();
                        break;
                }
            }

            return _driver;
        }
        catch (Exception ex)
        {
            MyLogger.Error($"Failed to create browser instance, {ex.Message}");
            throw new Exception("Failed to create browser instance.", ex);
        }
    }

    private static IWebDriver GetChromeConfiguredBrowser()
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--start-maximized");
        var service = ChromeDriverService.CreateDefaultService();
        var chromeDriver = new ChromeDriver(service, chromeOptions, TimeSpan.FromMinutes(2));
        return chromeDriver;
    }

    private static IWebDriver GetSafariConfiguredBrowser()
    {
        var safariBrowser = new SafariDriver();
        safariBrowser.Manage().Window.Maximize();
        return safariBrowser;
    }
}