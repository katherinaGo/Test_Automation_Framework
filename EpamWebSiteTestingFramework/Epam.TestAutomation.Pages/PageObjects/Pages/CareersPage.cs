using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.DriverCreator;

namespace Epam.TestAutomation.Pages.PageObjects.Pages;

public class CareersPage : BasePage
{
    private const string CareersPageLink = "https://www.epam.com/careers";

    public override bool IsOpened() => Browser.Driver.GetUrl().Equals(CareersPageLink);
}