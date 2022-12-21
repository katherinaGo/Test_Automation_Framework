using OpenQA.Selenium;
using OpenQA.Selenium.Safari;

namespace Epam.TestAutomation.Core.Browser;

public class SafariBrowser
{
    public IWebDriver GetDriver()
    {
        var safariBrowser = new SafariDriver();
        safariBrowser.Manage().Window.Maximize();
        return safariBrowser;
    }
}