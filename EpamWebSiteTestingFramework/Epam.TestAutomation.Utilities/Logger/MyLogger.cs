using Serilog;

namespace Epam.TestAutomation.Utilities.Logger;

public static class MyLogger
{
    private static ILogger? _logger;

    public static void Info(string message)
    {
        _logger?.Information(message);
    }

    public static void InitLogger(string loggerName, string pathToFolder)
    {
        Directory.CreateDirectory(pathToFolder);

        _logger = new LoggerConfiguration()
            .WriteTo.File(Path.Combine(pathToFolder, loggerName + ".txt"), rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }

    public static void Error(string message)
    {
        _logger?.Error(message);
    }
}