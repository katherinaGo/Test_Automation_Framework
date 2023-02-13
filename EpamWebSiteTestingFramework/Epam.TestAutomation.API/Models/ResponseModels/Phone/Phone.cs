using Epam.TestAutomation.API.Models.SharedModels.Phone;

namespace Epam.TestAutomation.API.Models.ResponseModels.Phone;

public class Phone
{
    public string id { get; set; }
    public string name { get; set; }
    public PhoneData? data { get; set; }
    public DateTime createdAt { get; set; }
}