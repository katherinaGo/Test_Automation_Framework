using Epam.TestAutomation.TestData.CareersJobListingsTestInfo;
using Epam.TestAutomation.Utilities.JsonParser;

namespace Epam.TestAutomation.TestData;

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

    private static readonly string PathToSearchProfessionsJson =
        Directory.GetCurrentDirectory() + "/TestData/TestDataProfessionsName.json";

    private static readonly string PathToSearchLocationsJson =
        Directory.GetCurrentDirectory() + "/TestData/TestDataLocations.json";

    private static readonly string PathToSearchSkillsJson =
        Directory.GetCurrentDirectory() + "/TestData/TestDataSkills.json";

    private static readonly string PathToAllFiltersToFindJobJson =
        Directory.GetCurrentDirectory() + "/TestData/TestDataAllFiltersToFindJob.json";

    private static readonly string PathToTwoFiltersToGetErrorJson =
        Directory.GetCurrentDirectory() + "/TestData/TestDataToGetErrorMessage.json";
}