using Epam.TestAutomation.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.PageObjects.Panels;

public class CookiesSettingsPanel : BaseElement
{
    public Button AcceptAllButton = new Button(By.Id("accept-recommended-btn-handler"));
    public Button RejectAllButton = new Button(By.XPath("//*[@class='ot-pc-refuse-all-handler']"));

    public Button ConfirmMyChoice = new Button(
        By.Id("//*[@class='save-preference-btn-handler onetrust-close-btn-handler']"));

    public Button CloseSettingsPanelButton = new Button(By.Id("close-pc-btn-handler"));

    public CookiesSettingsPanel(By locator) : base(locator)
    {
    }
}