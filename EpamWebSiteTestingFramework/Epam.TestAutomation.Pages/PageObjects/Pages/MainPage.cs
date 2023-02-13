using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.DriverCreator;
using Epam.TestAutomation.Core.Elements;
using Epam.TestAutomation.Core.Helper;
using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Pages.PageObjects.Panels;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.PageObjects.Pages;

public class MainPage : BasePage
{
    public Header EpamHeader => new(By.XPath("//*[@class='header-ui']"));

    public Label EngineeringTheFutureBanner => new(By
        .XPath("//*[contains(@class, 'background-video-ui')]"));

    public Button SliderButton => new(By.XPath("//*[@class='slider__navigation']"));

    public override bool IsOpened()
    {
        return Browser.Driver.GetUrl().Equals(UiTestSettings.ApplicationUrl);
    }

    public void OpenUrl()
    {
        Browser.Driver.GotToWebPageUrl(UiTestSettings.ApplicationUrl);
    }

    public void OpenJoinOurTeamPage()
    {
        Waiter.WaitForCondition(EpamHeader.CareersLink.IsElementEnabled);
        EpamHeader.CareersLink.HoverOnElement();
        Waiter.WaitForCondition(EpamHeader.CareersBlog.IsElementDisplayedOnPage);
        EpamHeader.CareerJoinOurTeam.Click();
    }

    public bool IsEngineeringTheFutureBannerDisplayed() => EngineeringTheFutureBanner.IsElementDisplayedOnPage();

    public bool IsEpamLogoDisplayed() => EpamHeader.EpamLogo.IsElementDisplayedOnPage();

    public bool IsSliderDisplayed() => SliderButton.IsElementDisplayedOnPage();
}