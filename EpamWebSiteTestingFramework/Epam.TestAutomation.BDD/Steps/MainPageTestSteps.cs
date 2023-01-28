using Epam.TestAutomation.Core.DriverCreator;
using Epam.TestAutomation.Core.Helper;
using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Pages.PageObjects.Pages;
using TechTalk.SpecFlow;

namespace Epam.TestAutomation.BDD.Steps;

[Binding]
public class MainPageTestSteps
{
    private MainPage _mainPage = new();

    [Given(@"The main page is opened")]
    public void GivenTheMainPageOpened()
    {
        Browser.Driver.GotToWebPageUrl(UiTestSettings.ApplicationUrl);
    }

    [When(@"Page is loaded")]
    public void WhenPageIsLoaded()
    {
        Waiter.WaitForPageLoading();
    }

    [Then(@"The loaded webpage has the same url")]
    public void ThenTheWebpageHasTheSameUrl()
    {
        var isPageOpened = _mainPage.IsOpened();
        Assert.That(isPageOpened, Is.True,
            $"Url '{MainPage.GetPageUrl()}' of opened page doesn't correspond to the main app url. ");
    }

    [Then(@"The Engineer banner is displayed on the main page")]
    public void ThenTheEngineerBannerIsDisplayedOnTheMainPage()
    {
        var isBannerDisplayed = _mainPage.IsEngineeringTheFutureBannerDisplayed();
        Assert.That(isBannerDisplayed, Is.True,
            $"'EngineeringTheFutureBanner' is not displayed on the page '{MainPage.GetPageUrl()}'");
    }

    [Then(@"The slider is displayed on the main page")]
    public void ThenTheSliderIsDisplayedOnTheMainPage()
    {
        var isSliderDisplayed = _mainPage.IsSliderDisplayed();
        Assert.That(isSliderDisplayed, Is.True,
            $"'EngineeringTheFutureBanner' is not displayed on the page '{MainPage.GetPageUrl()}'");
    }
}