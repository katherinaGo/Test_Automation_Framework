using Epam.TestAutomation.Pages.PageObjects.Pages;

namespace Epam.TestAutomation.Tests;

public class MainPageTests : BaseTest
{
    private MainPage _mainPage;

    [SetUp]
    public void PagesSetUp()
    {
        _mainPage = new MainPage();
    }

    [Test]
    public void CheckIfMainPageIsOpenedTest()
    {
        var isPageOpened = _mainPage.IsOpened();
        Assert.That(isPageOpened, Is.True,
            "Url of opened page doesn't correspond to the main app url. ");
    }

    [Test]
    public void CheckIfEngineerBannerDisplayed()
    {
        var isBannerDisplayed = _mainPage.IsEngineeringTheFutureBannerDisplayed();
        Assert.That(isBannerDisplayed, Is.True,
            "'EngineeringTheFutureBanner' is not displayed on the page.");
    }

    [Test]
    public void CheckIfSliderDisplayed()
    {
        var isSliderDisplayed = _mainPage.IsSliderDisplayed();
        Assert.That(isSliderDisplayed, Is.True,
            "'Slider' is not displayed on the page.");
    }
}