using Epam.TestAutomation.Pages.PageObjects.Pages;

namespace Epam.TestAutomation.Tests;

public class HeaderTests : BaseTest
{
    [Test]
    public void CheckIfEpamLogoDisplayed()
    {
        var isLogoDisplayed = MainPage.IsEpamLogoDisplayed();
        Assert.That(isLogoDisplayed, Is.True,
            $"'Epam logo' is not displayed on the page ");
    }
}