using System.Drawing;
using System.Drawing.Imaging;
using Epam.TestAutomation.Core.Helper;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Utilities.ScreenShotMaker;

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

        var screenPath = Path.Combine(UiTestSettings.ScreenShotPath, screenFileName);

        using (Image screenshot =
               Image.FromStream(new MemoryStream(((ITakesScreenshot)driver).GetScreenshot().AsByteArray)))
        {
            screenshot.Save(screenPath);
        }
    }
}