using Newtonsoft.Json;

namespace Epam.TestAutomation.TestData.CareersJobListingsTestInfo;

public class ProfessionsName
{
    [JsonProperty("keywordToFindJob")] public string? SearchJobKeyWord;
}