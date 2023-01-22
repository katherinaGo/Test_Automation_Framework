using Epam.TestAutomation.Pages.PageObjects.Pages;
using TechTalk.SpecFlow;

namespace Epam.TestAutomation.BDD.Steps;

[Binding]
public class JobListingsTestSteps
{
    private MainPage _mainPage = new();

    [Given(@"The job listings page is opened")]
    public void GivenTheJobListingsPageIsOpened()
    {
        // _mainPage.OpenJoinOurTeamPage();
    }
}