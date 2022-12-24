using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Elements;
using Epam.TestAutomation.Core.Helper;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.PageObjects.Pages;

public class MainPage : BasePage
{
    public Label EngineeringTheFutureBanner = new Label(
        By.XPath("//*[contains(@class, 'background-video-ui background-video--narrow')]"));

    public override bool IsOpened()
    {
        if (DriverFactory.Driver.Url.Equals(UiTestSettings.ApplicationUrl()))
        {
            return true;
        }

        return false;
    }
}