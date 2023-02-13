using Newtonsoft.Json;

namespace Epam.TestAutomation.API.Models.SharedModels.Phone;

public class PhoneData
{
    [JsonProperty("CPU model")] public string CPU_model { get; set; }
    [JsonProperty("Hard disk size")] public string Hard_disk_size { get; set; }
    [JsonProperty("Strap Colour")] public string Strap_Colour { get; set; }
    [JsonProperty("Case Size")] public string Case_Size { get; set; }
    [JsonProperty("Screen_size")] public double Screen_size { get; set; }
    public string color { get; set; }
    public string capacity { get; set; }
    public double price { get; set; }
    public int year { get; set; }
    public string Description { get; set; }
    public int yea2 { get; set; }
    public string Generation { get; set; }
}