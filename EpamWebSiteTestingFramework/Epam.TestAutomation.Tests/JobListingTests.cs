using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Pages.PageObjects.Pages;
using Epam.TestAutomation.TestData.CareersJobListingsTestInfo;

namespace Epam.TestAutomation.Tests;

[TestFixture]
public class JobListingTests : BaseTest
{
    private MainPage _mainPage;
    private JobSearchResultPage _resultPage;
    private JobListingsPage _listingPage;

    [SetUp]
    public void SetUpPages()
    {
        _mainPage = new();
        _resultPage = new();
        _listingPage = new();
    }

    [Test]
    [TestCaseSource(nameof(GetProfessionsNamesTestData))]
    public void CheckSearchResultsRelatedToProfessionsTest(ProfessionsName searchWord)
    {
        _mainPage.OpenJoinOurTeamPage();
        _listingPage.FillFiltersWithSearchJobData(job: searchWord.SearchJobKeyWord);
        Waiter.WaitForCondition(() => _listingPage.SearchResultList.IsElementDisplayedOnPage());
        var isResultFound = _resultPage.IsFoundResultDisplayed(job: searchWord.SearchJobKeyWord);
        Assert.That(isResultFound, Is.True,
            $"Found result doesn't contain search word '{searchWord.SearchJobKeyWord}'.");
    }

    [Test]
    [TestCaseSource(nameof(GetLocationsTestData))]
    public void CheckSearchResultsRelatedToLocationsTest(LocationsNameModel searchWord)
    {
        _mainPage.OpenJoinOurTeamPage();
        _listingPage.FillFiltersWithSearchJobData(location: searchWord.SearchLocationKeyWord);
        var isResultFound = _resultPage.IsFoundResultDisplayed(location: searchWord.SearchLocationKeyWord);
        Assert.That(isResultFound, Is.True,
            $"Found result doesn't contain search word '{searchWord.SearchLocationKeyWord}'.");
    }

    [Test]
    [TestCaseSource(nameof(GetSkillsTestData))]
    public void CheckSearchResultsRelatedToSkillsTest(SkillsNameModel searchWord)
    {
        _mainPage.OpenJoinOurTeamPage();
        _listingPage.FillFiltersWithSearchJobData(skill: searchWord.SearchSkillsKeyWord);
        var isResultFound = _resultPage.IsFoundResultDisplayed(skill: searchWord.SearchSkillsKeyWord);
        Assert.That(isResultFound, Is.True,
            $"Nothing was found with skill: '{searchWord.SearchSkillsKeyWord}'.");
    }

    [Test]
    [TestCaseSource(nameof(GetAllJobsFiltersTestData))]
    public void CheckSearchResultsRelatedToAllFiltersTest(JobSearchByAllFiltersModel model)
    {
        _mainPage.OpenJoinOurTeamPage();
        _listingPage.FillFiltersWithSearchJobData(model.ProffessionName, model.SkillName, model.LocationName);
        Waiter.WaitForCondition(() => _listingPage.SearchResultList.IsElementDisplayedOnPage());
        var isJobFound = _resultPage.IsFoundResultDisplayed(job: model.ProffessionName);
        var isSkillFound = _resultPage.IsFoundResultDisplayed(skill: model.SkillName);
        var isLocationFound = _resultPage.IsFoundResultDisplayed(location: model.LocationName);
        Assert.Multiple(() =>
        {
            Assert.That(isJobFound, Is.True,
                $"Found result doesn't contain search word '{model.ProffessionName}'.");
            Assert.That(isSkillFound, Is.True,
                $"Found result doesn't contain search word '{model.SkillName}'.");
            Assert.That(isLocationFound, Is.True,
                $"Found result doesn't contain search word '{model.LocationName}'.");
        });
    }

    [Test]
    [TestCaseSource(nameof(GetTestDataJobAndLocation))]
    public void CheckErrorMessageDisplayedWhenNothingFoundTest(TestDataToGetErrorModel model)
    {
        _mainPage.OpenJoinOurTeamPage();
        _listingPage.FillFiltersWithSearchJobData(job: model.JobName, location: model.LocationName);
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

    private static List<ProfessionsName> GetProfessionsNamesTestData() => TestDataSettings.SearchProfessions;
    private static List<LocationsNameModel> GetLocationsTestData() => TestDataSettings.SearchLocations;
    private static List<SkillsNameModel> GetSkillsTestData() => TestDataSettings.SearchSkills;
    private static List<JobSearchByAllFiltersModel> GetAllJobsFiltersTestData() => TestDataSettings.AllJobFilters;
    private static List<TestDataToGetErrorModel> GetTestDataJobAndLocation() => TestDataSettings.TwoFiltersData;
}