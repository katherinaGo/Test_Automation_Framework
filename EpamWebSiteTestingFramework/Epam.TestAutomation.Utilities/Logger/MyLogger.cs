using Serilog;

namespace Epam.TestAutomation.Utilities.Logger;

public class MyLogger
{
    private static List<string> _logs = new();

    public static void Info(string message)
    {
        _logs.Add(message);
    }

    public static void InitLogger(string filePath)
    {
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug().WriteTo.File(Path.Combine(filePath, "logs.txt"))
            .CreateLogger();
    }

    public static void FinishTestLog()
    {
        _logs.ForEach(x => Log.Logger.Information(x));
        _logs.Clear();
    }
}