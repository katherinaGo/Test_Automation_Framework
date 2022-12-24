using Epam.TestAutomation.Core.Browser;

namespace Epam.TestAutomation.Core.BasePage;

public abstract class BasePage
{
    public abstract bool IsOpened();

    public static string GetPageUrl() => DriverFactory.Driver.GetUrl();

    public static string GetPageTitle() => DriverFactory.Driver.Title;
}