using Epam.TestAutomation.Pages.PageObjects.Pages;

namespace Epam.TestAutomation.Tests;

public class MainPageTests : BaseTest
{
    private MainPage MainPage { get; set; }

    [SetUp]
    public void SetUp()
    {
        MainPage = new MainPage();
    }

    [Test]
    public void CheckIfMainPageIsOpenedTest()
    {
        var isPageOpened = MainPage.IsOpened();
        Assert.That(isPageOpened, Is.True,
            $"Url '{MainPage.GetPageUrl()}' of opened page doesn't correspond to the main app url. ");
    }

    [Test]
    public void CheckIfEngineerBannerDisplayed()
    {
        var isBannerDisplayed = MainPage.IsEngineeringTheFutureBannerDisplayed();
        Assert.That(isBannerDisplayed, Is.True,
            $"'EngineeringTheFutureBanner' is not displayed on the page '{MainPage.GetPageUrl()}'");
    }
}