using Epam.TestAutomation.API.Models.SharedModels.Phone;

namespace Epam.TestAutomation.API.Models.RequestModels.Phone;

public class PhoneModel
{
    public string name { get; set; }
    public PhoneData? data { get; set; }
}