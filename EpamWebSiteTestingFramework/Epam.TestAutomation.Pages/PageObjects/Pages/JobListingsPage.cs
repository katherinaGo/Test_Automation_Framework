using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.DriverCreator;
using Epam.TestAutomation.Core.Elements;
using Epam.TestAutomation.Core.Helper;
using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Utilities.Logger;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.PageObjects.Pages;

public class JobListingsPage : BasePage
{
    public TextInput KeywordInputField => new(By.XPath("//*[@id='new_form_job_search_1445745853_copy-keyword']"));

    public Dropdown LocationsDropdown => new(By.XPath("//*[@class='select2-selection select2-selection--single']"));

    public ElementsList LocationsDropdownList => new(By.XPath("//*[@class='select2-results__option']"));
    public Panel DropdownLocationsPanel => new(By.XPath("//*[@class='select2-results__options open']"));

    public Button FindButton => new(By.XPath("//*[@type='submit']"));

    public Button SelectedLocationChosen(string cityName) =>
        new(By.XPath($"//*[@class='select2-selection__rendered'][contains(text(), '{cityName}')]"));

    public Button ChosenCityLine =>
        new(By.XPath("//*[@class='select2-results__option select2-results__option--highlighted']"));

    public TextInput LocationInput => new(By.XPath("//*[@class='select2-search__field']"));

    public Label SkillsSection => new(By.XPath("//*[@class='default-label'][contains(text(), 'All Skills')]"));

    public Dropdown SkillsDropdownPanel =>
        new(By.XPath("//*[@class='multi-select-dropdown' and contains(@role, 'tree')]"));

    public Checkbox SkillOption(string skill) =>
        new(By.XPath($"//*[@class='checkbox-custom-label'][contains(text(), '{skill}')]"));

    public Label ChosenSkillFilter => new(By.XPath("//*[@class='filter-tag']"));

    public Panel FiltersPanel => new(By.Id("jobSearchFilterForm"));

    public Label ErrorMessageWhenNoJobsFound =>
        new(By.XPath("//*[@class='search-result__error-message'][contains(text(), 'Sorry, your search')]"));

    public override bool IsOpened()
    {
        return Browser.Driver.GetUrl().Equals(UiTestSettings.JobListingUrl);
    }

    public override void OpenUrl()
    {
        Browser.Driver.GotToWebPageUrl(UiTestSettings.JobListingUrl);
        Waiter.WaitForCondition(() => KeywordInputField.IsElementDisplayedOnPage());
    }

    public void SearchJobsByKeyword(string searchWord)
    {
        KeywordInputField.SendKeys(searchWord);
        FindButton.Click();
    }

    public void SearchJobLocationsByKeyWord(string searchWord)
    {
        Waiter.WaitForCondition(FiltersPanel.IsElementDisplayedOnPage);
        LocationsDropdown.Click();
        Waiter.WaitForCondition(DropdownLocationsPanel.IsElementDisplayedOnPage);
        LocationInput.SendKeys(searchWord);
        ChosenCityLine.Click();
        Waiter.WaitForCondition(SelectedLocationChosen(searchWord).IsElementDisplayedOnPage);
    }

    public void SearchJobSkillsByKeyWord(string searchWord)
    {
        SkillsSection.Click();
        Waiter.WaitForCondition(() => !SkillsDropdownPanel.GetTextFromAttribute("class").Contains("hidden"));
        SkillOption(searchWord).Click();
        FindButton.Click();
        Waiter.WaitForCondition(ChosenSkillFilter.IsElementDisplayedOnPage);
    }

    public void FillFiltersWithSearchJobData(string job, string skill, string location)
    {
        if (!string.IsNullOrEmpty(job))
        {
            KeywordInputField.SendKeys(job);
        }

        if (!string.IsNullOrEmpty(location))
        {
            LocationsDropdown.Click();
            Waiter.WaitForCondition(DropdownLocationsPanel.IsElementDisplayedOnPage);
            LocationInput.SendKeys(location);
            ChosenCityLine.Click();
        }

        if (!string.IsNullOrEmpty(skill))
        {
            SkillsSection.Click();
            Waiter.WaitForCondition(() => !SkillsDropdownPanel.GetTextFromAttribute("class").Contains("hidden"));
            var isErrorMessageDisplayed = false;
            try
            {
                ErrorMessageWhenNoJobsFound.IsElementDisplayedOnPage();
                isErrorMessageDisplayed = true;
            }
            catch (NoSuchElementException e)
            {
                MyLogger.Info(e.Message + ". Error message is not displayed.");
                SkillOption(skill).Click();
                FindButton.Click();
            }

            if (isErrorMessageDisplayed.Equals(true))
            {
                FindButton.Click();
            }
        }
    }
}