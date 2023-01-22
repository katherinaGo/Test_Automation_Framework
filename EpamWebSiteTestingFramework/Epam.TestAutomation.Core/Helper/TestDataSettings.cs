using Epam.TestAutomation.TestData.CareersJobListingsTestInfo;
using Epam.TestAutomation.Utilities.JsonParser;

namespace Epam.TestAutomation.Core.Helper;

public static class TestDataSettings
{
    public static List<ProfessionsName> SearchProfessions =>
        JsonParser.Deserialize<List<ProfessionsName>>(PathToSearchProfessionsJson);

    public static List<LocationsNameModel> SearchLocations =>
        JsonParser.Deserialize<List<LocationsNameModel>>(PathToSearchLocationsJson);

    public static List<SkillsNameModel> SearchSkills =>
        JsonParser.Deserialize<List<SkillsNameModel>>(PathToSearchSkillsJson);

    public static List<JobSearchByAllFiltersModel> AllJobFilters =>
        JsonParser.Deserialize<List<JobSearchByAllFiltersModel>>(PathToAllFiltersToFindJobJson);

    public static List<TestDataToGetErrorModel> TwoFiltersData =>
        JsonParser.Deserialize<List<TestDataToGetErrorModel>>(PathToTwoFiltersToGetErrorJson);

    private const string PathToSearchProfessionsJson =
        "/Users/kate/RiderProjects/Test_Automation_Framework/EpamWebSiteTestingFramework/Epam.TestAutomation.TestData/CareersJobListingsTestInfo/TestDataProfessionsName.json";

    private const string PathToSearchLocationsJson =
        "/Users/kate/RiderProjects/Test_Automation_Framework/EpamWebSiteTestingFramework/Epam.TestAutomation.TestData/CareersJobListingsTestInfo/TestDataLocations.json";

    private const string PathToSearchSkillsJson =
        "/Users/kate/RiderProjects/Test_Automation_Framework/EpamWebSiteTestingFramework/Epam.TestAutomation.TestData/CareersJobListingsTestInfo/TestDataSkills.json";

    private const string PathToAllFiltersToFindJobJson =
        "/Users/kate/RiderProjects/Test_Automation_Framework/EpamWebSiteTestingFramework/Epam.TestAutomation.TestData/CareersJobListingsTestInfo/TestDataAllFiltersToFindJob.json";

    private const string PathToTwoFiltersToGetErrorJson =
        "/Users/kate/RiderProjects/Test_Automation_Framework/EpamWebSiteTestingFramework/Epam.TestAutomation.TestData/CareersJobListingsTestInfo/TestDataToGetErrorMessage.json";
}