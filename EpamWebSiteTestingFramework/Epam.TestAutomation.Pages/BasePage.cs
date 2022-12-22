using Epam.TestAutomation.Core.Browser;

namespace Epam.TestAutomation.Pages;

public abstract class BasePage
{
    protected abstract bool IsOpened();

    protected static string GetPageUrl() => DriverFactory.Driver.GetUrl();

    protected static string GetPageTitle() => DriverFactory.Driver.Title;
}