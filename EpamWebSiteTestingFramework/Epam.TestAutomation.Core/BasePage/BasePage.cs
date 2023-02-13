using Epam.TestAutomation.Core.DriverCreator;

namespace Epam.TestAutomation.Core.BasePage;

public abstract class BasePage
{
    public abstract bool IsOpened();

    public static string GetPageUrl() => Browser.Driver.GetUrl();
    public static string GetPageTitle() => Browser.Driver.Title;
}