using Epam.TestAutomation.Pages.PageObjects.Pages;
using TechTalk.SpecFlow;

namespace Epam.TestAutomation.BDD.Steps;

[Binding]
public class HeaderPanelTestSteps
{
    private MainPage _mainPage = new();

    [Then(@"The Epam Logo is displayed on the page")]
    public void ThenTheEpamLogoIsDisplayedOnThePage()
    {
        var isLogoDisplayed = _mainPage.IsEpamLogoDisplayed();
        Assert.That(isLogoDisplayed, Is.True,
            $"'Epam logo' is not displayed on the page '{MainPage.GetPageUrl()}'");
    }
}