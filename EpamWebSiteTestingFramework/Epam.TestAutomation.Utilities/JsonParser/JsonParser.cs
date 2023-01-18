using Newtonsoft.Json;

namespace Epam.TestAutomation.Utilities.JsonParser;

public static class JsonParser
{
    public static string SerializeJson(object content) => JsonConvert.SerializeObject(content);

    public static T Deserialize<T>(string path) => JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
}