using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.DriverCreator;
using Epam.TestAutomation.Core.Elements;
using Epam.TestAutomation.Core.Helper;
using Epam.TestAutomation.Core.Utils;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.PageObjects.Pages;

public class JobListingsPage : BasePage
{
    private JobSearchResultPage _resultPage;
    private JobDetailsPage _detailsPage;
    public TextInput KeywordInputField => new(By.XPath("//*[@id='new_form_job_search_1445745853_copy-keyword']"));

    public Dropdown LocationsDropdown =>
        new Dropdown(By.XPath("//*[@class='select2-selection select2-selection--single']"));

    public ElementsList LocationsDropdownList => new(By.XPath("//*[@class='select2-results__option']"));
    public Panel DropdownLocationsPanel => new Panel(By.XPath("//*[@class='select2-results__options open']"));

    public Button FindButton => new(By.XPath("//*[@type='submit']"));

    public Button SelectedLocationChosen(string cityName) =>
        new Button(By.XPath($"//*[@class='select2-selection__rendered'][contains(text(), '{cityName}')]"));

    public Button ChosenCityLine =>
        new Button(By.XPath("//*[@class='select2-results__option select2-results__option--highlighted']"));

    public TextInput LocationInput => new TextInput(By.XPath("//*[@class='select2-search__field']"));

    public Label SkillsSection => new Label(By.XPath("//*[@class='default-label'][contains(text(), 'All Skills')]"));

    public Dropdown SkillsDropdownPanel =>
        new Dropdown(By.XPath("//*[@class='multi-select-dropdown' and @aria-hidden='false']"));

    public Checkbox SkillOption(string skill) =>
        new Checkbox(By.XPath($"//*[@class='checkbox-custom-label'][contains(text(), '{skill}')]"));

    public Label ChosenSkillFilter => new Label(By.XPath("//*[@class='filter-tag']"));

    public Panel FiltersPanel => new Panel(By.Id("jobSearchFilterForm"));

    public JobListingsPage()
    {
        _resultPage = new();
        _detailsPage = new();
    }

    public override bool IsOpened()
    {
        return Browser.Driver.GetUrl().Equals(UiTestSettings.JobListingUrl);
    }

    public override void OpenUrl()
    {
        Browser.Driver.GotToWebPageUrl(UiTestSettings.JobListingUrl);
        Waiter.WaitForPageLoading();
        Waiter.WaitForCondition(() => KeywordInputField.IsElementDisplayedOnPage());
    }

    public JobSearchResultPage SearchJobsByKeyword(string searchWord)
    {
        KeywordInputField.SendKeys(searchWord);
        FindButton.Click();
        Waiter.WaitForCondition(_resultPage.SearchResultHeadingTitle.IsElementDisplayedOnPage);
        return new JobSearchResultPage();
    }

    public JobSearchResultPage SearchJobLocationsByKeyWord(string searchWord)
    {
        LocationsDropdown.Click();
        Waiter.WaitForCondition(DropdownLocationsPanel.IsElementDisplayedOnPage);
        LocationInput.SendKeys(searchWord);
        ChosenCityLine.Click();
        Waiter.WaitForCondition(SelectedLocationChosen(searchWord).IsElementDisplayedOnPage);
        return new JobSearchResultPage();
    }

    public JobSearchResultPage SearchJobSkillsByKeyWord(string searchWord)
    {
        SkillsSection.Click();
        Thread.Sleep(1300); // can't find locator for skillsDropdown panel that it could work without Thread.Sleep 
        SkillOption(searchWord).Click();
        FindButton.Click();
        Waiter.WaitForCondition(ChosenSkillFilter.IsElementDisplayedOnPage);
        return new JobSearchResultPage();
    }

    public JobSearchResultPage FillFiltersWithSearchJobData(string job, string skill, string location)
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
        return new JobSearchResultPage();
    }

    public JobSearchResultPage FillFiltersWithSearchJobDataToGetErrorMessage(string job, string location)
    {
        KeywordInputField.SendKeys(job);
        LocationsDropdown.Click();
        Waiter.WaitForCondition(DropdownLocationsPanel.IsElementDisplayedOnPage);
        LocationInput.SendKeys(location);
        ChosenCityLine.Click();
        FindButton.Click();
        return new JobSearchResultPage();
    }
}