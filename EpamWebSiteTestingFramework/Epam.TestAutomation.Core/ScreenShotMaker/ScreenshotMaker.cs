using Epam.TestAutomation.Core.DriverCreator;
using Epam.TestAutomation.Utilities.Logger;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Core.ScreenShotMaker;

public static class ScreenshotMaker
{
    private static void TakeScreenshot(IWebDriver driver, string methodName, string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        var screenShooter = driver as ITakesScreenshot;
        var screenShot = screenShooter?.GetScreenshot();
        screenShot?.SaveAsFile($"{folderPath}/{DateTime.Now:MM.dd.yyyy, HH:mm:ss}_{methodName}.jpeg",
            ScreenshotImageFormat.Png);
    }

    public static void SaveScreenshot(string screenshotName, string folderPath)
    {
        try
        {
            MyLogger.Info("Generating of screenshot started.");
            TakeScreenshot(Browser.Driver, screenshotName, folderPath);
            MyLogger.Info("Generating of screenshot finished.");
        }
        catch (Exception ex)
        {
            MyLogger.Info($"Failed to capture screenshot. Exception message {ex.Message}");
        }
    }
}