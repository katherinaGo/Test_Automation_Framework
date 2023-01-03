using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Elements;
using Epam.TestAutomation.Core.Helper;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.PageObjects.Pages;

public class MainPage : BasePage
{
    private readonly Label EngineeringTheFutureBanner = new Label(
        By.XPath("//*[contains(@class, 'background-video-ui background-video--narrow')]"));

    private readonly Button SliderButton = new Button(By.XPath("//*[@class='slider__navigation']"));

    private readonly Label EpamLogo = new Label(By.XPath("//*[@class='header__logo']"));

    public override bool IsOpened() => DriverFactory.Driver.GetUrl().Equals(UiTestSettings.ApplicationUrl);

    public bool IsEngineeringTheFutureBannerDisplayed() => EngineeringTheFutureBanner.IsElementDisplayedOnPage();

    public bool IsEpamLogoDisplayed() => EpamLogo.IsElementDisplayedOnPage();

    public bool IsSliderDisplayed() => SliderButton.IsElementDisplayedOnPage();
}