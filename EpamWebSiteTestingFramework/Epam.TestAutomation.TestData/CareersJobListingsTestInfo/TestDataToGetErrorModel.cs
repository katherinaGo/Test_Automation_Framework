using Newtonsoft.Json;

namespace Epam.TestAutomation.TestData.CareersJobListingsTestInfo;

public class TestDataToGetErrorModel
{
    [JsonProperty("keywordToFindJob")] public string? SkillName;

    [JsonProperty("keywordToFindJobLocation")]
    public string? LocationName;
}