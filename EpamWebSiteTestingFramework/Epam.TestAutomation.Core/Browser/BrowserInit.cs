using OpenQA.Selenium;

namespace Epam.TestAutomation.Core.Browser;

public class BrowserInit
{
    private static IWebDriver InitializeBrowser(BrowserType browserType)
    {
        try
        {
            IWebDriver? driver = null;
            switch (browserType)
            {
                case BrowserType.Chrome:
                    driver = new ChromeBrowser().GetDriver();
                    break;
                case BrowserType.Safari:
                    driver = new SafariBrowser().GetDriver();
                    break;
                default:
                    driver = new ChromeBrowser().GetDriver();
                    break;
            }

            return driver;
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to create browser instance", ex);
        }
    }
}