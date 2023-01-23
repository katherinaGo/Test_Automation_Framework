using Epam.TestAutomation.Pages.PageObjects.Pages;
using TechTalk.SpecFlow;

namespace Epam.TestAutomation.BDD.Steps;

[Binding]
public class JobListingsTestSteps
{
    private JobListingsPage _jobListingsPage = new();
    private JobSearchResultPage _resultPage = new();

    [Given(@"The job listings page is opened from the main page")]
    public void GivenTheJobListingsPageIsOpened()
    {
        _jobListingsPage.OpenUrl();
    }

    [When(@"Enter job name (.*)")]
    public void WhenEnterJobName(string keyword)
    {
        _jobListingsPage.SearchJobsByKeyword(keyword);
    }

    [Then(@"The result that contains the (.*) is displayed on the page")]
    public void ThenTheResultThatContainsTheQaIsDisplayedOnThePage(string keyword)
    {
        var isResultFound = _resultPage.IsFoundResultHasSearchWord(keyword);
        Assert.That(isResultFound, Is.True,
            $"Found result doesn't contain search word '{keyword}'.");
    }

    [When(@"Enter job and location names (.*), (.*)")]
    public void WhenEnterJobAndLocationNames(string job, string location)
    {
        _jobListingsPage.OpenUrl();
        _jobListingsPage.FillFiltersWithSearchJobDataToGetErrorMessage(job, location);
    }

    [Then(@"The error message is displayed on the page that nothing was found")]
    public void ThenTheErrorMessageIsDisplayedOnThePageThatNothingWasFound()
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