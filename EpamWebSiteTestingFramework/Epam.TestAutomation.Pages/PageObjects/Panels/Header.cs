using Epam.TestAutomation.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.PageObjects.Panels;

public class Header : Panel
{
    public Panel HeaderPanel => new Panel(By.XPath("//*[@class='header-ui']"));
    public Label EpamLogo => new Label(By.XPath("//*[@class='header__logo']"));
    public Link Services => new Link(By.XPath("//*[@class='top-navigation__item-link' and @href='/services']"));
    public Link HowWeDoIt => new Link(By.XPath("//*[@class='top-navigation__item-link' and @href='/how-we-do-it']"));
    public Link OurWork => new Link(By.XPath("//*[@class='top-navigation__item-link' and @href='/our-work']"));
    public Link Insights => new Link(By.XPath("//*[@class='top-navigation__item-link' and @href='/insights']"));

    public Link About => new Link(By.XPath("//*[@class='top-navigation__item-link' and @href='/about']"));
    public Link CareersLink => new Link(By.XPath("//*[@class='top-navigation__item-link' and @href='/careers']"));

    public Button CareerJoinOurTeam =>
        new Button(By.XPath("//*[@href='/careers/job-listings'][text()='Join our Team']"));

    public Button CareerEpamWithoutBorders =>
        new Button(By.XPath("//*[@href='/careers/epam-without-borders'][text()='Relocate with EPAM']"));
    public Link Careers => new Link(By.XPath("//*[@class='top-navigation__item-link' and @href='/careers']"));
    public Button ContactUsButton => new Button(By.XPath("//*[@class='cta-button__text']"));
    public Dropdown LanguageDropdown => new Dropdown(By.XPath("//*[@class='location-selector__button']"));
    public Button SearchButton => new Button(By.XPath("//*[@class='header-search__button header__icon']"));

    public ElementsList HeaderButtons =>
        new ElementsList(By.XPath("//*[@class='top-navigation__item-link']"));
    public Button CareerHiringLocations =>
        new Button(By.XPath("//*[@href='/careers/locations'][text()='Hiring Locations']"));

    public Button CareersReferralProgram =>
        new Button(By.XPath("//*[@href='/careers/external-referral-program'][text()='Referral Program']"));

    public Button CareersBlog =>
        new Button(By.XPath("//*[@href='/careers/blog'][text()='Blog']"));
    public Header(By locator) : base(locator)
    {
    }
}