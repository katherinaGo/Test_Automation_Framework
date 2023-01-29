using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.DriverCreator;
using Epam.TestAutomation.Core.Elements;
using Epam.TestAutomation.Core.Helper;
using Epam.TestAutomation.Core.Utils;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.PageObjects.Pages;

public class JobSearchResultPage : BasePage
{
    public ElementsList FoundResultList => new(By.XPath("//*[@class='search-result__item-name']"));

    public Label SearchResultHeadingTitle => new(By.XPath("//*[@class='search-result__heading']"));

    public Label ErrorMessageWhenNoJobsFound =>
        new(By.XPath("//*[@class='search-result__error-message' and @role ='alert']"));

    public override bool IsOpened()
    {
        return Browser.Driver.GetUrl().Equals(UiTestSettings.JobListingUrl);
    }

    public override void OpenUrl()
    {
        Browser.Driver.GetUrl().Equals(UiTestSettings.JobListingUrl);
    }

    public bool IsFoundResultHasSearchWord(string searchWord)
    {
        Waiter.WaitForCondition(SearchResultHeadingTitle.IsElementDisplayedOnPage);
        var foundResult = FoundResultList.GetElements().Select(
            itemResult => itemResult.GetAttribute("innerText").Contains(searchWord));
        return foundResult.Any();
    }

    public bool IsErrorMessageIsDisplayedIfNothingFound()
    {
        Waiter.WaitForCondition(ErrorMessageWhenNoJobsFound.IsElementOnView);
        return ErrorMessageWhenNoJobsFound.IsElementDisplayedOnPage();
    }

    public string GetActualErrorMessageFromPage() => ErrorMessageWhenNoJobsFound.GetTextFromAttribute("innerText");
}