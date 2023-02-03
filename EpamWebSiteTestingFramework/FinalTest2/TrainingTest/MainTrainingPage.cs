using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.DriverCreator;
using Epam.TestAutomation.Core.Elements;
using Epam.TestAutomation.Core.Utils;
using OpenQA.Selenium;

namespace FinalTest2.TrainingTest;

public class MainTrainingPage : BasePage
{
    private string TrainingsMainUrl = "https://training.by";
    public Panel HeroBanner => new(By.XPath("//*[@class='hero-banner hero-banner--home']"));

    public Dropdown ChangeLanguageDropdownButton => new(By
        .XPath("//*[contains(@class, 'menu-control__toggle language-control') and @aria-expanded = 'false']"));

    public Label ENLanguage => new(By
        .XPath("//*[contains(@class, 'menu-control__toggle language-control')][contains(text(), 'EN')]"));

    public Label RULanguage => new(By
        .XPath("//*[contains(@class, 'menu-control__toggle language-control')][contains(text(), 'RU')]"));

    public Label UALanguage => new(By
        .XPath("//*[contains(@class, 'menu-control__toggle language-control')][contains(text(), 'UA')]"));

    public Dropdown LanguageDropdown => new(By
        .XPath("//*[contains(@class, 'menu-control__list language-') and @role= 'menu']"));

    public Button Language(Languages language) => new(By
        .XPath($"//*[contains(@class, 'menu-control__item language')][contains(text(),'{language.ToString()}')]"));

    public override bool IsOpened()
    {
        return Browser.Driver.GetUrl().Equals(TrainingsMainUrl);
    }

    public void OpenMainPage()
    {
        Browser.Driver.GotToWebPageUrl(TrainingsMainUrl);
    }

    public void ChangeLanguage(Languages chosenLanguage)
    {
        ChangeLanguageDropdownButton.Click();
        Waiter.WaitForCondition(LanguageDropdown.IsElementDisplayedOnPage);
        Language(chosenLanguage).Click();
        Waiter.WaitForCondition(() => HeroBanner.IsElementDisplayedOnPage());
    }

    public bool IsNeededLanguageChosen(string lang)
    {
        return Browser.Driver.GetUrl().Contains(lang);
    }
}