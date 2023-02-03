using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.DriverCreator;
using Epam.TestAutomation.Core.Elements;
using OpenQA.Selenium;

namespace FinalTest2.EpamTest;

public class CareerPage : BasePage
{
    private static string CareerLink = "https://www.epam.com/careers";

    public Button LearnMore => new(By
        .XPath("//*[contains(@class, 'button-ui') and @href = 'https://www.epam.com/support-ukraine']"));

    public override bool IsOpened()
    {
        return Browser.Driver.GetUrl().Equals(CareerLink);
    }

    public void OpenCareerPage()
    {
        Browser.Driver.GotToWebPageUrl(CareerLink);
    }

    public bool CheckIfLearnMoreButtonIsDisplayedOnPage()
    {
        return LearnMore.IsElementDisplayedOnPage();
    }
}