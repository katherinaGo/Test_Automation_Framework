using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Pages.PageObjects.Pages;
using TechTalk.SpecFlow;

namespace Epam.TestAutomation.BDD.Steps;

[Binding]
public class JobListingsTestSteps
{
    private JobListingsPage _jobListingsPage = new();
    private JobSearchResultPage _resultPage = new();

    [Given(@"The job listings page is opened")]
    public void GivenTheJobListingsPageIsOpened()
    {
        _jobListingsPage.OpenUrl();
    }

    [Given(@"Enter job name (.*)")]
    [When(@"Enter job name (.*)")]
    public void EnterJobName(string keyword)
    {
        _jobListingsPage.SearchJobsByKeyword(keyword);
        Waiter.WaitForCondition(_resultPage.SearchResultHeadingTitle.IsElementDisplayedOnPage);
    }

    [Then(@"The result that contains the (.*) is displayed on the page")]
    [When(@"The result that contains the (.*) is displayed on the page")]
    public void ThenTheResultThatContainsTheIsDisplayedOnThePage(string keyword)
    {
        var isResultFound = _resultPage.IsFoundResultHasSearchWord(keyword);
        if (isResultFound == false)
        {
            Assert.Fail($"Found result doesn't contain search word '{keyword}'.");
        }
    }

    [When(@"Enter job and location names (.*), (.*) in the search panel")]
    public void WhenEnterJobAndLocationNamesInTheSearchPanel(string job, string location)
    {
        _jobListingsPage.OpenUrl();
        _jobListingsPage.FillFiltersWithSearchJobDataToGetErrorMessage(job, location);
    }

    [Then(@"The error message is displayed on the result page that nothing was found")]
    private void ThenTheErrorMessageIsDisplayedOnTheResultPageThatNothingWasFound()
    {
        var isErrorMessageDisplayed = _resultPage.IsErrorMessageIsDisplayedIfNothingFound();
        var expectedErrorMessage = "Sorry, your search returned no results. Please try another combination.";
        var actualErrorMessage = _resultPage.GetActualErrorMessageFromPage();
        Assert.Multiple(() =>
            {
                Assert.That(isErrorMessageDisplayed, Is.True,
                    "Error message that noting found is not displayed on the page, or smth was found.");
                Assert.That(expectedErrorMessage.Equals(actualErrorMessage),
                    "Error message doesn't correspond to expected one.");
            }
        );
    }
}