using Newtonsoft.Json;

namespace Epam.TestAutomation.TestData.CareersJobListingsTestInfo;

public class LocationsNameModel
{
    [JsonProperty("keywordToFindJobLocation")]
    public string? SearchLocationKeyWord;
}