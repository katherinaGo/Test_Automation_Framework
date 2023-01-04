using Epam.TestAutomation.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.PageObjects.Panels;

public class CookiesBanner : Panel
{
    public Panel CookiesPanel = new Panel(By.Id("onetrust-banner-sdk"));
    public Link CookiesSettings = new Link(By.Id("onetrust-pc-btn-handler"));
    public Button AcceptAllButton = new Button(By.Id("onetrust-accept-btn-handler"));
    public Link LearnMoreCookiePolicy = new Link(By.XPath("//*[@aria-label='More information about your privacy']"));

    public CookiesBanner(By locator) : base(locator)
    {
    }
}