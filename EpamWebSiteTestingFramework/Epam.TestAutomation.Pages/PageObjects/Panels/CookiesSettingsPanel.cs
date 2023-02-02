using Epam.TestAutomation.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.PageObjects.Panels;

public class CookiesSettingsPanel : Panel
{
    public Button AcceptAllButton => new Button(By.Id("accept-recommended-btn-handler"));
    public Button RejectAllButton => new Button(By.XPath("//*[@class='ot-pc-refuse-all-handler']"));

    public Button ConfirmMyChoice => new(By
        .Id("//*[contains(@class, 'save-preference-btn-handler')]"));

    public Button CloseSettingsPanelButton => new Button(By.Id("close-pc-btn-handler"));

    public CookiesSettingsPanel(By locator) : base(locator)
    {
    }
}