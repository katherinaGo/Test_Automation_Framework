using System.Drawing;
using System.Drawing.Imaging;
using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Helper;
using Epam.TestAutomation.Utilities.Logger;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Core.ScreenShotMaker;

public class ScreenshotMaker
{
    public static void TakeScreenshot(IWebDriver driver, string testName, string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        var screenFileName =
            $"{testName} {DateTime.Now:dd,MM}.{ImageFormat.Jpeg.ToString().ToLowerInvariant()}";

        var screenPath = Path.Combine(UiTestSettings.ScreenshotPath, screenFileName);

        using (Image screenshot =
               Image.FromStream(new MemoryStream(((ITakesScreenshot)driver).GetScreenshot().AsByteArray)))
        {
            screenshot.Save(screenPath);
        }
    }

    public static void SaveScreenshot(string screenshotName, string folderPath)
    {
        try
        {
            MyLogger.Info("Generating of screenshot started.");
            ScreenshotMaker.TakeScreenshot(DriverFactory.Driver, screenshotName, folderPath);
            MyLogger.Info("Generating of screenshot finished.");
        }
        catch (Exception ex)
        {
            MyLogger.Info($"Failed to capture screenshot. Exception message {ex.Message}");
        }
    }
}