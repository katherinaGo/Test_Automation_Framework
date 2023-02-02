using Epam.TestAutomation.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.PageObjects.Panels;

public class Header : Panel
{
    public Panel HeaderPanel => new(By.XPath("//*[@class='header-ui']"));
    public Label EpamLogo => new(By.XPath("//*[@class='header__logo']"));
    public Link Services => new(By.XPath("//*[@class='top-navigation__item-link' and @href='/services']"));
    public Link HowWeDoIt => new(By.XPath("//*[@class='top-navigation__item-link' and @href='/how-we-do-it']"));
    public Link OurWork => new(By.XPath("//*[@class='top-navigation__item-link' and @href='/our-work']"));
    public Link Insights => new(By.XPath("//*[@class='top-navigation__item-link' and @href='/insights']"));

    public Link About => new(By.XPath("//*[@class='top-navigation__item-link' and @href='/about']"));
    public Link CareersLink => new(By.XPath("//*[@class='top-navigation__item-link' and @href='/careers']"));

    public Button CareerJoinOurTeam => new(By
        .XPath("//*[contains(@class,'top-navigation__main-link') and @href='/careers/job-listings']"));

    public Button CareerEpamWithoutBorders => new(By
        .XPath("//*[contains(@class,'top-navigation__main-link') and @href='/careers/epam-without-borders']"));

    public Link Careers => new(By.XPath("//*[@class='top-navigation__item-link' and @href='/careers']"));

    public Button CareerHiringLocations => new(By
        .XPath("//*[contains(@class,'top-navigation__main-link') and @href='/careers/locations']"));

    public Button CareersReferralProgram => new(By
        .XPath("//*[contains(@class,'top-navigation__main-link') and @href='/careers/external-referral-program']"));

    public Button CareersBlog => new(By
        .XPath("//*[contains(@class,'top-navigation__main-link') and @href='/careers/blog']"));

    public Button ContactUsButton => new(By.XPath("//*[@class='cta-button__text']"));
    public Dropdown LanguageDropdown => new(By.XPath("//*[@class='location-selector__button']"));
    public Button SearchButton => new(By.XPath("//*[@class='header-search__button header__icon']"));

    public ElementsList HeaderButtons => new(By.XPath("//*[@class='top-navigation__item-link']"));

    public Header(By locator) : base(locator)
    {
    }
}