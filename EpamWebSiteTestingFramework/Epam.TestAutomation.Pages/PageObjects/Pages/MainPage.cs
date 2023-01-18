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
    private JobListingsPage _jobListingsPage;
    public Header EpamHeader => new Header(By.XPath("//*[@class='header-ui']"));

    public Label EngineeringTheFutureBanner => new Label(
        By.XPath("//*[contains(@class, 'background-video-ui background-video--narrow')]"));

    public Button SliderButton => new Button(By.XPath("//*[@class='slider__navigation']"));

    public MainPage()
    {
        _jobListingsPage = new JobListingsPage();
    }

    public override bool IsOpened()
    {
        return Browser.Driver.GetUrl().Equals(UiTestSettings.ApplicationUrl);
    }

    public override void OpenUrl()
    {
        Browser.Driver.GotToWebPageUrl(UiTestSettings.ApplicationUrl);
    }

    public JobListingsPage OpenJoinOurTeamPage()
    {
        EpamHeader.CareersLink.HoverOnElement();
        Waiter.WaitForCondition(EpamHeader.CareersBlog.IsElementDisplayedOnPage);
        EpamHeader.CareerJoinOurTeam.Click();
        Waiter.WaitForCondition(_jobListingsPage.FiltersPanel.IsElementDisplayedOnPage);
        return new JobListingsPage();
    }

    public bool IsEngineeringTheFutureBannerDisplayed() => EngineeringTheFutureBanner.IsElementDisplayedOnPage();

    public bool IsEpamLogoDisplayed() => EpamHeader.EpamLogo.IsElementDisplayedOnPage();

    public bool IsSliderDisplayed() => SliderButton.IsElementDisplayedOnPage();
}