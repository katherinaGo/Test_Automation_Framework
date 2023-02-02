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

    public Button CareerJoinOurTeam => new Button(By
        .XPath("//*[contains(@class,'top-navigation__main-link') and @href='/careers/job-listings']"));

    public Button CareerEpamWithoutBorders => new Button(By
        .XPath("//*[contains(@class,'top-navigation__main-link') and @href='/careers/epam-without-borders']"));

    public Link Careers => new Link(By.XPath("//*[@class='top-navigation__item-link' and @href='/careers']"));

    public Button CareerHiringLocations => new Button(By
        .XPath("//*[contains(@class,'top-navigation__main-link') and @href='/careers/locations']"));

    public Button CareersReferralProgram => new Button(By
        .XPath("//*[contains(@class,'top-navigation__main-link') and @href='/careers/external-referral-program']"));

    public Button CareersBlog => new Button(By
        .XPath("//*[contains(@class,'top-navigation__main-link') and @href='/careers/blog']"));

    public Button ContactUsButton => new Button(By.XPath("//*[@class='cta-button__text']"));
    public Dropdown LanguageDropdown => new Dropdown(By.XPath("//*[@class='location-selector__button']"));
    public Button SearchButton => new Button(By.XPath("//*[@class='header-search__button header__icon']"));

    public ElementsList HeaderButtons => new(By.XPath("//*[@class='top-navigation__item-link']"));

    public Header(By locator) : base(locator)
    {
    }
}