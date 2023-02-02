using Epam.TestAutomation.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.PageObjects.Panels;

public class Footer : BaseElement
{
    public Panel FooterPanel => new(By.XPath("//*[@class='footer-ui']"));
    public Label OurBrands => new(By.XPath("//*[@class='footer__brands-title']"));
    public Link EpamContinuumLinks => new(By.XPath("//*[@href='/epam-continuum']"));
    public Link TelescopeAI => new(By.XPath("//*[@href='https://www.telescopeai.com/']"));
    public Link InfoNgen => new(By.XPath("//*[@href='https://www.infongen.com/']"));
    public Link TestIO => new(By.XPath("//*[@href='https://test.io/']"));
    public Link EpamAnyWhere => new(By.XPath("//*[@href='https://anywhere.epam.com/']"));
    public Label CopyRites => new(By.XPath(" //*[@class='footer__copyright']"));
    public Link Investors => new(By.XPath("//*[@href='/about/investors']"));
    public Link OpenSource => new(By.XPath("//*[@href='/open-source']"));
    public Link PrivacyPolicy => new(By.XPath("//*[@href='/privacy-policy']"));
    public Link CookiePolicy => new(By.XPath("//*[@href='/cookie-policy']"));
    public Link ApplicantPrivacyNotice => new(By.XPath("//*[@href='/applicant-privacy-notice']"));
    public Link WebAccessibility => new(By.XPath("//*[@href='/web-accessibility-statement']"));

    public Link LinkedIn => new(By
        .XPath("//*[@class='footer__social-link' and @href='https://www.linkedin.com/company/epam-systems/']"));

    public Link Twitter => new(By
        .XPath("//*[@class='footer__social-link' and @href='https://twitter.com/EPAMSYSTEMS']"));

    public Link FaceBook => new(By
        .XPath("//*[@class='footer__social-link' and @href='https://www.facebook.com/EPAM.Global']"));

    public Link Instagram => new Link(By
        .XPath("//*[@class='footer__social-link' and @href='https://www.instagram.com/epamsystems/']"));

    public Link YouTube => new(By
        .XPath("//*[@class='footer__social-link' and @href='https://www.youtube.com/c/EPAMSystemsGlobal']"));

    public Footer(By locator) : base(locator)
    {
    }
}