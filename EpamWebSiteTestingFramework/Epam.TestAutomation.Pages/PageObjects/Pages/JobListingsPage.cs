using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.DriverCreator;
using Epam.TestAutomation.Core.Elements;
using Epam.TestAutomation.Core.Helper;
using Epam.TestAutomation.Core.Utils;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.PageObjects.Pages;

public class JobListingsPage : BasePage
{
    public TextInput KeywordInputField => new(By.XPath("//*[@id='new_form_job_search_1445745853_copy-keyword']"));

    public Dropdown LocationsDropdown => new(By.XPath("//*[@class='select2-selection select2-selection--single']"));

    public Panel DropdownLocationsPanel => new(By.XPath("//*[@class='select2-results__options open']"));

    public Button FindButton => new(By.XPath("//*[@type='submit']"));

    public Button SelectedLocationChosen(string cityName) => new(By
        .XPath($"//*[@class='select2-selection__rendered'][contains(text(), '{cityName}')]"));

    public Button ChosenCityLine => new(By
        .XPath("//*[@class='select2-results__option select2-results__option--highlighted']"));

    public TextInput LocationInput => new(By.XPath("//*[@class='select2-search__field']"));

    public Label SkillsSection => new(By.XPath("//*[@class='default-label'][contains(text(), 'All Skills')]"));

    public Dropdown SkillsDropdownPanel => new(By
        .XPath("//*[@class='multi-select-dropdown' and contains(@aria-expanded, 'true')]"));

    public Checkbox SkillOption(string skill) => new(By
        .XPath($"//*[@class='checkbox-custom-label'][contains(text(), '{skill}')]"));

    public Label ChosenSkillFilter => new(By.XPath("//*[@class='filter-tag']"));

    public Panel FiltersPanel => new(By.Id("jobSearchFilterForm"));

    public Label ErrorMessageDropdownWhenNoSkillsFound => new(By
        .XPath("//*[@class='multi-select-dropdown' and @role='tree']/*[@class='search-result__error-message']"));

    public Panel SearchResultList => new(By
        .XPath("//*[@class='search-result__heading' and contains(text(), 'related')]"));

    public override bool IsOpened()
    {
        return Browser.Driver.GetUrl().Equals(UiTestSettings.JobListingUrl);
    }

    public override void OpenUrl()
    {
        Browser.Driver.GotToWebPageUrl(UiTestSettings.JobListingUrl);
        Waiter.WaitForCondition(() => KeywordInputField.IsElementDisplayedOnPage());
    }

    public void FillFiltersWithValidSearchJobData(string job = null, string skill = null, string location = null)
    {
        if (!string.IsNullOrEmpty(job))
        {
            KeywordInputField.SendKeys(job);
            FindButton.Click();
            Waiter.WaitForCondition(() => SearchResultList.IsElementDisplayedOnPage());
        }

        if (!string.IsNullOrEmpty(location))
        {
            Waiter.WaitForCondition(() => FiltersPanel.IsElementDisplayedOnPage());
            LocationsDropdown.Click();
            Waiter.WaitForCondition(() => DropdownLocationsPanel.IsElementDisplayedOnPage());
            LocationInput.SendKeys(location);
            ChosenCityLine.Click();
            Waiter.WaitForCondition(() => SelectedLocationChosen(location).IsElementDisplayedOnPage());
        }

        if (!string.IsNullOrEmpty(skill))
        {
            SkillsSection.Click();
            Waiter.WaitForCondition(() => !SkillsDropdownPanel.GetTextFromAttribute("class").Contains("hidden"));
            SkillOption(skill).Click();
            Waiter.WaitForCondition(() => ChosenSkillFilter.IsElementDisplayedOnPage());
        }
    }

    public void FillFiltersWithInValidSearchJobData(string job = null, string skill = null, string location = null)
    {
        if (!string.IsNullOrEmpty(job))
        {
            KeywordInputField.SendKeys(job);
            FindButton.Click();
        }

        if (!string.IsNullOrEmpty(location))
        {
            Waiter.WaitForCondition(FiltersPanel.IsElementDisplayedOnPage);
            LocationsDropdown.Click();
            Waiter.WaitForCondition(() => DropdownLocationsPanel.IsElementDisplayedOnPage());
            LocationInput.SendKeys(location);
            ChosenCityLine.Click();
            Waiter.WaitForCondition(() => SelectedLocationChosen(location).IsElementDisplayedOnPage());
        }

        if (!string.IsNullOrEmpty(skill))
        {
            SkillsSection.Click();
            Waiter.WaitForCondition(() => !SkillsDropdownPanel.GetTextFromAttribute("class").Contains("hidden"));
            Waiter.WaitForCondition(() => ErrorMessageDropdownWhenNoSkillsFound.IsElementDisplayedOnPage());
        }
    }
}