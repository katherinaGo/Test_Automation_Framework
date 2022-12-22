using Epam.TestAutomation.Core.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;

namespace Epam.TestAutomation.Core.Browser;

public static class DriverFactory
{
    private static IWebDriver _webDriver;
    public static IWebDriver Driver => GetWebBrowser(UiTestSettings.Browser);

    private static IWebDriver GetWebBrowser(BrowserType browserType)
    {
        try
        {
            if (_webDriver == null)
            {
                switch (browserType)
                {
                    case BrowserType.Chrome:
                        _webDriver = GetChromeConfiguredBrowser();
                        break;
                    case BrowserType.Safari:
                        _webDriver = GetSafariConfiguredBrowser();
                        break;
                    default:
                        _webDriver = GetChromeConfiguredBrowser();
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to create browser instance", ex);
        }

        return _webDriver;
    }

    private static IWebDriver GetChromeConfiguredBrowser()
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--start-maximized");
        var service = ChromeDriverService.CreateDefaultService();
        var chromeDriver = new ChromeDriver(service, chromeOptions, TimeSpan.FromMinutes(3));
        return chromeDriver;
    }

    private static IWebDriver GetSafariConfiguredBrowser()
    {
        var safariBrowser = new SafariDriver();
        safariBrowser.Manage().Window.Maximize();
        return safariBrowser;
    }
}