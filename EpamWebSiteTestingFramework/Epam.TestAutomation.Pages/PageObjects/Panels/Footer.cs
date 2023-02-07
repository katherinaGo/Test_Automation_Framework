using Epam.TestAutomation.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.PageObjects.Panels;

public class Footer : BaseElement
{
    public Panel FooterPanel => new(By.XPath("//*[@class='footer-ui']"));
    public Label OurBrands => new(By.XPath("//*[@class='footer__brands-title']"));
    public Link EpamContinuumLinks => new(By.XPath("//*[@href='/epam-continuum']"));
    public Button TelescopeAI => new(By.XPath("//*[@class='footer__brands-image'][@alt='TelescopeAI']"));
    public Button InfoNgen => new(By.XPath("//*[@class='footer__brands-image'][@alt='InfoNgen']"));
    public Button TestIO => new(By.XPath("//*[@href='https://test.io/']"));
    public Button EpamAnyWhere => new(By.XPath("//*[@class='footer__brands-image'][@alt='EPAM Anywhere']"));
    public Label CopyRites => new(By.XPath("//*[@class='footer__copyright']"));
    public Button Investors => new(By.XPath("//*[@class='footer__links-item'][contains(text(),'Investors')]"));
    public Button OpenSource => new(By.XPath("//*[@class='footer__links-item'][contains(text(),'Open Source')]"));
    public Button PrivacyPolicy => new(By.XPath("//*[@class='footer__links-item'][contains(text(),'Privacy Policy')]"));
    public Button CookiePolicy => new(By.XPath("//*[@class='footer__links-item'][contains(text(),'Cookie Policy')]"));

    public Button ApplicantPrivacyNotice =>
        new(By.XPath("//*[@class='footer__links-item'][contains(text(),'Applicant Privacy Notice')]"));

    public Button WebAccessibility =>
        new(By.XPath("//*[@class='footer__links-item'][contains(text(),'Web Accessibility')]"));

    public Button LinkedIn => new(By.XPath("//*[@class='footer__social-link'][@data-type='li']"));

    public Button Twitter => new(By.XPath("//*[@class='footer__social-link'][@data-type='tw']"));

    public Button FaceBook => new(By.XPath("//*[@class='footer__social-link'][@data-type='fb']"));

    public Button Instagram => new(By.XPath("//*[@class='footer__social-link'][@data-type='instagram-filled']"));

    public Button YouTube => new(By.XPath("//*[@class='footer__social-link'][@data-type='youtube']"));

    public Footer(By locator) : base(locator)
    {
    }
}