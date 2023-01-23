using Epam.TestAutomation.Pages.PageObjects.Pages;
using TechTalk.SpecFlow;

namespace Epam.TestAutomation.BDD.Steps;

[Binding]
public class JobApplyToWorkTestSteps
{
    private JobListingsPage _jobListingPage = new();
    private JobSearchResultPage _resultPage = new();
    private JobDetailsPage _detailsPage = new();

    [Given(@"Enter job name (.*)")]
    public void GivenEnterJobName(string keyword)
    {
        _jobListingPage.SearchJobsByKeyword(keyword);
    }

    [When(
        @"The result that contains the (.*) is displayed on the page and by pressing button the job details page is opened")]
    public void WhenTheResultThatContainsTheIsDisplayedOnThePageAndByPressingButtonJobDetailsIsOpened(string keyword)
    {
        var isResultFound = _resultPage.IsFoundResultHasSearchWord(keyword);
        if (isResultFound)
        {
            _detailsPage.ClickViewAndApplyOnFirstJobToOpenDetails();
        }
        else
        {
            Assert.Fail("Nothing was found, impossible to open job details page.");
        }
    }

    [Then(@"Entering (.*), (.*),(.*) to apply the job is available")]
    public void ThenEnteringDataToApplyTheJobIsAvailable(string name, string lastName, string email)
    {
        _detailsPage.FillUpTheMandatoryFields(name, lastName, email);
        var areFieldsContainInputData =
            _detailsPage.CheckIfMandatoryFieldsAreFilled(name, lastName, email);
        Assert.That(areFieldsContainInputData, Is.True, "Mandatory fields don't contains needed info.");
    }
}