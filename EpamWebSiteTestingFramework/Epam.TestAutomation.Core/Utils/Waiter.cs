using Epam.TestAutomation.Core.DriverCreator;

namespace Epam.TestAutomation.Core.Utils;

public static class Waiter
{
    public static void WaitForPageLoading() => Browser.Driver.Waiters().Until(condition =>
        Browser.Driver.ExecuteScript("return document.readyState").Equals("complete"));

    public static void WaitForCondition(Func<bool> condition) =>
        Browser.Driver.Waiters().Until(x => condition.Invoke());
}