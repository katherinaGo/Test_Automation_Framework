using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.DriverCreator;
using Epam.TestAutomation.Core.Elements;
using Epam.TestAutomation.Core.Helper;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.PageObjects.Pages;

public class JobSearchResultPage : BasePage
{
    private readonly string _jobSearchResultPageUrl = UiTestSettings.JobListingUrl + "?recruitingUrl=";
    public ElementsList FoundResultList => new(By.XPath("//*[@class='search-result__item-name']"));

    public Label SearchResultHeadingTitle => new(By.XPath("//*[@class='search-result__heading']"));

    public Label ErrorMessageWhenNoJobsFound => new(By
        .XPath("//*[@class='search-result__error-message' and contains(@role, 'alert')]"));

    public Button ViewAndApply => new(By.XPath("//*[@class='search-result__item-apply']"));

    public Panel SearchPanel => new(By.Id("jobSearchFilterForm"));

    public bool IsErrorMessageIsDisplayedIfNothingFound() => ErrorMessageWhenNoJobsFound.IsElementDisplayedOnPage();

    public string GetActualErrorMessageFromPage() => ErrorMessageWhenNoJobsFound.GetTextFromAttribute("innerText");

    public override bool IsOpened()
    {
        return Browser.Driver.GetUrl().Contains(_jobSearchResultPageUrl);
    }

    public bool IsFoundResultHasSearchWord(string searchWord)
    {
        var foundResult = FoundResultList.GetElements().Select(
            itemResult => itemResult.GetAttribute("innerText").Contains(searchWord));
        return foundResult.Any();
    }
}