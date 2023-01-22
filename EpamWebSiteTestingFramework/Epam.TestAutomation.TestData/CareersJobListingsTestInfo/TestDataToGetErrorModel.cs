using Newtonsoft.Json;

namespace Epam.TestAutomation.TestData.CareersJobListingsTestInfo;

public class TestDataToGetErrorModel
{
    [JsonProperty("keywordToFindJob")] public string? SKillName;

    [JsonProperty("keywordToFindJobLocation")]
    public string? LocationName;
}