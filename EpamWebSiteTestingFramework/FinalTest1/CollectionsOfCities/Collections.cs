namespace FinalTest1.CollectionsOfCities;

public class Collections
{
    private static List<string> Cities = new()
    {
        "Vilnius", // 7
        "Porto", // 5
        "Victoria", // 8
        "Vancouver" // 9
    };

    private static List<string> ResultCollection()
    {
        return Cities
            .Where(city => city.Length % 2 == 0)
            .Select(city => city.Replace(city.First(), 'a')).ToList();
    }

    public static void PrintResultCollection()
    {
        var newCollection = ResultCollection();
        foreach (var city in newCollection)
        {
            Console.WriteLine(city);
        }
    }
}