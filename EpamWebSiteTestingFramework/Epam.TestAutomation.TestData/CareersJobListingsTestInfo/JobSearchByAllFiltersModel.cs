using Newtonsoft.Json;

namespace Epam.TestAutomation.TestData.CareersJobListingsTestInfo;

public class JobSearchByAllFiltersModel
{
    [JsonProperty("searchProfessionName")] public string ProffessionName;
    [JsonProperty("searchLocation")] public string LocationName;
    [JsonProperty("searchSkill")] public string SkillName;
}