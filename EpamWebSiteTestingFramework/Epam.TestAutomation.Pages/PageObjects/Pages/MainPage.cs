using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.DriverCreator;
using Epam.TestAutomation.Core.Elements;
using Epam.TestAutomation.Core.Helper;
using Epam.TestAutomation.Pages.PageObjects.Panels;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.PageObjects.Pages;

public class MainPage : BasePage
{
    private Header EpamHeader => new Header(By.XPath("//*[@class='header-ui']"));

    private Label EngineeringTheFutureBanner => new Label(
        By.XPath("//*[contains(@class, 'background-video-ui background-video--narrow')]"));

    private Button SliderButton => new Button(By.XPath("//*[@class='slider__navigation']"));

    public override bool IsOpened() => Browser.Driver.GetUrl().Equals(UiTestSettings.ApplicationUrl);

    public bool IsEngineeringTheFutureBannerDisplayed() => EngineeringTheFutureBanner.IsElementDisplayedOnPage();

    public bool IsEpamLogoDisplayed() => EpamHeader.EpamLogo.IsElementDisplayedOnPage();

    public bool IsSliderDisplayed() => SliderButton.IsElementDisplayedOnPage();
}