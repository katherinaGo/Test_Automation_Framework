using Epam.TestAutomation.Pages.PageObjects.Pages;
using TechTalk.SpecFlow;

namespace Epam.TestAutomation.BDD.Steps;

[Binding]
public class JobApplyToWorkTestSteps
{
    private JobDetailsPage _detailsPage = new();
    private JobSearchResultPage _resultPage = new();

    [When(@"By pressing 'ViewAndApply' button the job details page is opened")]
    public void WhenByPressingButtonTheJobDetailsPageIsOpened()
    {
        _resultPage.ViewAndApply.Click();
        _detailsPage.OpenDetailsOfFirstJob();
    }

    [Then(@"Entering (.*) to apply the job is available")]
    public void ThenEnteringDataToApplyTheJobIsAvailable(string testValue)
    {
        _detailsPage.FillUpTheMandatoryFields(testValue);
        var areFieldsContainInputData = _detailsPage.CheckIfMandatoryFieldsAreFilled(testValue);
        Assert.That(areFieldsContainInputData, Is.True, "Mandatory fields don't contains needed info.");
    }
}