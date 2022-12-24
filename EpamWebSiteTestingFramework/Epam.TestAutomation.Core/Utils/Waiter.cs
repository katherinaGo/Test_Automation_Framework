using Epam.TestAutomation.Core.Browser;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Core.Utils;

public static class Waiter
{
    public static void WaitForPageLoading() => DriverFactory.Driver.Waiters().Until(condition =>
        DriverFactory.Driver.ExecuteScript("return document.readyState").Equals("complete"));

    public static void WaitForCondition(Func<bool> condition) =>
        DriverFactory.Driver.Waiters().Until(x => condition.Invoke());

    public static void WaitSpinner()
    {
        DriverFactory.Driver.Waiters().Until(x =>
            !DriverFactory.Driver.FindElement(By.XPath("//div[contains(@class,'grid__spinner')]")).Displayed);
    }
}