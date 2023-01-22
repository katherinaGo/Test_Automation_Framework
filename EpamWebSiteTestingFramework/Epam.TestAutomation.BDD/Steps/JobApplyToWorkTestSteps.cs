using TechTalk.SpecFlow;

namespace Epam.TestAutomation.BDD.Steps;

[Binding]
public class JobApplyToWorkTestSteps
{
    // private JobListingPage _jobListingPage = new JobListingPage();
    // private JobSearchResultPage _resultPage = new JobSearchResultPage();
    // private JobDetailsPage _detailsPage = new JobDetailsPage();

    [Given(@"Enter job name (.*)")]
    public void GivenEnterJobName(string keyword)
    {
        // _jobListingPage.SearchJobsByKeyword(keyword);
    }

    [When(
        @"The result that contains the (.*) is displayed on the page and by pressing button the job details page is opened")]
    public void WhenTheResultThatContainsTheIsDisplayedOnThePageAndByPressingButtonJobDetailsIsOpened(string keyword)
    {
        //     var isResultFound = _resultPage.IsFoundResultHasSearchWord(keyword);
        //     if (isResultFound)
        //     {
        //         _resultPage.ClickOnFirstJobToOpenDetails();
        //     }
        //     else
        //     {
        //         Assert.Fail("Nothing was found, impossible to open job details page.");
        //     }
    }

    [Then(@"Entering (.*), (.*),(.*) to apply the job is available")]
    public void ThenEnteringDataToApplyTheJobIsAvailable()
    {
        // _detailsPage.FillUpTheMandatoryFields();
        // var areFieldsContainInputData = _detailsPage.CheckIfMandatoryFieldsIsFilled();
        // Assert.That(areFieldsContainInputData, Is.True, "Mandatory fields don't contains needed info.");
    }
}