using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.DriverCreator;
using Epam.TestAutomation.Core.Elements;
using Epam.TestAutomation.Core.Helper;
using Epam.TestAutomation.Core.Utils;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.PageObjects.Pages;

public class JobSearchResultPage : BasePage
{
    public ElementsList FoundResultListForJobs => new(By.XPath("//*[@class='search-result__item-name']"));

    public ElementsList FoundResultListForLocations => new(By.XPath("//*[@class='search-result__location']"));
    private readonly string _jobSearchResultPageUrl = UiTestSettings.JobListingUrl + "?recruitingUrl=";
    public ElementsList FoundResultList => new(By.XPath("//*[@class='search-result__item-name']"));

    public Label SearchResultHeadingTitle => new(By.XPath("//*[@class='search-result__heading']"));

    public Label ErrorMessageWhenNoJobsFound => new(By
        .XPath("//*[@class='search-result__error-message' and contains(@role, 'alert')]"));

    public Button ViewAndApply => new(By.XPath("//*[@class='search-result__item-apply']"));

    public Panel SearchPanel => new(By.Id("jobSearchFilterForm"));

    public Label ResultHeadingLabelWithSearchingWord(string searchWord) => new(By
        .XPath($"//*[@class='search-result__heading'][contains(text(), '{searchWord}')]"));

    public override bool IsOpened()
    {
        return Browser.Driver.GetUrl().Contains(_jobSearchResultPageUrl);
    }

    public void OpenUrl()
    {
        Browser.Driver.GetUrl().Equals(UiTestSettings.JobListingUrl);
    }

    public bool IsFoundResultDisplayed(string job = null, string location = null, string skill = null)
    {
        if (job != null)
        {
            return FoundResultListForJobs
                .GetElements()
                .Select(itemResult => itemResult.GetAttribute("innerText").ToLower())
                .Any(item => item.Contains(job));
        }

        if (location != null)
        {
            return FoundResultListForLocations
                .GetElements()
                .Select(itemResult => itemResult.GetAttribute("innerText").ToLower())
                .Any(item => item.Contains(location.ToLower()));
        }

        if (skill != null)
        {
            return SearchResultHeadingTitle.IsElementDisplayedOnPage();
        }

        return false;
    }

    public bool IsErrorMessageIsDisplayedIfNothingFound()
    {
        Waiter.WaitForCondition(ErrorMessageWhenNoJobsFound.IsElementOnView);
        return ErrorMessageWhenNoJobsFound.IsElementDisplayedOnPage();
    }

    public string GetActualErrorMessageFromPage() => ErrorMessageWhenNoJobsFound.GetTextFromAttribute("innerText");
}