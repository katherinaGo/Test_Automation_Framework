using System.Collections.ObjectModel;
using Epam.TestAutomation.Core.Helper;
using Epam.TestAutomation.Utilities.Logger;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Epam.TestAutomation.Core.DriverCreator;

public static class Browser
{
    public static IWebDriver Driver => DriverFactory.GetWebBrowser();

    public static string GetUrl(this IWebDriver webDriver)
    {
        return webDriver.Url;
    }

    public static void GoBack(this IWebDriver webDriver)
    {
        webDriver!.Navigate().Back();
    }

    public static void RefreshPage(this IWebDriver webDriver)
    {
        webDriver!.Navigate().Refresh();
    }

    public static void GotToWebPageUrl(this IWebDriver webDriver, string url)
    {
        webDriver.Navigate().GoToUrl(url);
    }

    public static void CloseBrowser(this IWebDriver webDriver)
    {
        MyLogger.Info("Close Browser.");
        webDriver.Close();
    }

    public static WebDriverWait Waiters(this IWebDriver webDriver)
    {
        return new WebDriverWait(webDriver, UiTestSettings.WebDriverTimeOut);
    }

    public static void QuitBrowser(this IWebDriver webDriver)
    {
        MyLogger.Info("Quit Browser.");
        try
        {
            webDriver.Quit();
            DriverFactory.DestroyWebBrowser();
        }

        catch (Exception ex)
        {
            MyLogger.Error($"Unable to Quit the browser. Reason: {ex.Message}");
        }
    }

    public static void ScrollTop(this IWebDriver webDriver)
    {
        ExecuteScript(webDriver, "$(window).scrollTop(0)");
    }

    public static void ScrollToElement(this IWebDriver webDriver, IWebElement element)
    {
        ExecuteScript(webDriver, "arguments[0].scrollIntoView(true);", element);
    }

    public static IWebElement FindTheElement(this IWebDriver webDriver, By locator)
    {
        return webDriver!.FindElement(locator);
    }

    public static ReadOnlyCollection<IWebElement> FindTheElements(this IWebDriver webDriver, By by)
    {
        return webDriver!.FindElements(by);
    }

    public static void SetSessionToken(this IWebDriver webDriver, string token)
    {
        var tokenValue = "{\"type\":\"bearer\",\"value\":\"" + token + " \"}";
        ExecuteScript(webDriver, "javascript:localStorage.token=arguments[0];", tokenValue);
    }

    public static object ExecuteScript(this IWebDriver webDriver, string script, params object[] args)
    {
        try
        {
            return ((IJavaScriptExecutor)webDriver!).ExecuteScript(script, args);
        }
        catch (WebDriverTimeoutException e)
        {
            MyLogger.Info($"Error: Timeout Exception thrown while running JS Script:{e.Message}-{e.StackTrace}");
        }

        return null!;
    }

    public static Actions GetActions(this IWebDriver webDriver)
    {
        return new Actions(webDriver);
    }

    public static void OpenNewTab(this IWebDriver webDriver)
    {
        webDriver.SwitchTo().NewWindow(WindowType.Tab);
    }
}