using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.DriverCreator;
using Epam.TestAutomation.Core.Elements;
using Epam.TestAutomation.Core.Helper;
using Epam.TestAutomation.Core.Utils;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.PageObjects.Pages;

public class JobListingsPage : BasePage
{
    public TextInput KeywordInputField => new(By.XPath("//*[@placeholder='Keyword']"));

    public Dropdown LocationsDropdown => new(By.XPath("//*[@title='All Locations'][@role='textbox']"));

    public ElementsList LocationsDropdownList => new(By.XPath("//*[@class='select2-results__option']"));
    public Panel DropdownLocationsPanel => new(By.XPath("//*[@class='select2-results__options open']"));

    public Button FindButton => new(By.XPath("//*[@type='submit']"));

    public Button SelectedLocationChosen(string cityName) =>
        new Button(By.XPath($"//*[@class='select2-selection__rendered'][contains(text(), '{cityName}')]"));

    public Button ChosenCityLine =>
        new(By.XPath(" //*[contains(@class, 'select2-results__option')][contains(@role, option)]"));

    public TextInput LocationInput => new(By.XPath("//*[@class='select2-search__field'][@type='text']"));

    public Label SkillsSection => new(By.XPath("//*[@class='selected-params ']/*[@class='default-label']"));

    public Dropdown SkillsDropdownPanel =>
        new(By.XPath("//*[@class='multi-select-dropdown' and contains(@aria-hidden, 'false')]"));

    public Checkbox SkillOption(string skill) =>
        new(By.XPath($"//*[@class='checkbox-custom-label'][contains(text(), '{skill}')]"));

    public Label ChosenSkillFilter => new(By.XPath("//*[@class='filter-tag']"));

    public Panel FiltersPanel => new(By.Id("jobSearchFilterForm"));

    public override bool IsOpened()
    {
        return Browser.Driver.GetUrl().Equals(UiTestSettings.JobListingUrl);
    }

    public void OpenUrl()
    {
        Browser.Driver.GotToWebPageUrl(UiTestSettings.JobListingUrl);
        Waiter.WaitForPageLoading();
        Waiter.WaitForCondition(() => KeywordInputField.IsElementDisplayedOnPage());
    }

    public void SearchJobsByKeyword(string searchWord)
    {
        Waiter.WaitForCondition(FiltersPanel.IsElementDisplayedOnPage);
        KeywordInputField.SendKeys(searchWord);
        FindButton.Click();
    }

    public void SearchJobLocationsByKeyWord(string searchWord)
    {
        LocationsDropdown.Click();
        Waiter.WaitForCondition(DropdownLocationsPanel.IsElementDisplayedOnPage);
        LocationInput.SendKeys(searchWord);
        ChosenCityLine.Click();
        Waiter.WaitForCondition(SelectedLocationChosen(searchWord).IsElementDisplayedOnPage);
    }

    public void SearchJobSkillsByKeyWord(string searchWord)
    {
        SkillsSection.Click();
        Thread.Sleep(1300); // can't find locator for skillsDropdown panel that it could work without Thread.Sleep 
        SkillOption(searchWord).Click();
        FindButton.Click();
        Waiter.WaitForCondition(ChosenSkillFilter.IsElementDisplayedOnPage);
    }

    public void FillFiltersWithSearchJobData(string job, string skill, string location)
    {
        KeywordInputField.SendKeys(job);
        LocationsDropdown.Click();
        Waiter.WaitForCondition(DropdownLocationsPanel.IsElementDisplayedOnPage);
        LocationInput.SendKeys(location);
        ChosenCityLine.Click();
        SkillsSection.Click();
        Thread.Sleep(1300); // can't find locator for skillsDropdown panel that it could work without Thread.Sleep 
        SkillOption(skill).Click();
        FindButton.Click();
    }

    public void FillFiltersWithSearchJobDataToGetErrorMessage(string job, string location)
    {
        KeywordInputField.SendKeys(job);
        LocationsDropdown.Click();
        Waiter.WaitForCondition(DropdownLocationsPanel.IsElementDisplayedOnPage);
        LocationInput.SendKeys(location);
        ChosenCityLine.Click();
        FindButton.Click();
    }
}