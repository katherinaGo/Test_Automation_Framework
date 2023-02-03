using Epam.TestAutomation.Core.DriverCreator;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Core.Utils;

public static class Waiter
{
    public static void WaitForPageLoading() => Browser.Driver.Waiters().Until(condition =>
        Browser.Driver.ExecuteScript("return document.readyState").Equals("complete"));

    public static void WaitForCondition(Func<bool> condition) =>
        Browser.Driver.Waiters().Until(x => condition.Invoke());

    public static void WaitSpinner()
    {
        Browser.Driver.Waiters().Until(x =>
            !Browser.Driver.FindElement(By.XPath("//div[contains(@class,'grid__spinner')]")).Displayed);
    }

    public static void WaitForPageLoadingJS()
    {
        Browser.Driver.Waiters()
            .Until(_driver => ((IJavaScriptExecutor)_driver).ExecuteScript("return document.readyState"))
            .Equals("complete");
    }
}