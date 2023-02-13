using Epam.TestAutomation.Pages.PageObjects.Pages;

namespace Epam.TestAutomation.Tests;

[TestFixture]
public class HeaderTests : BaseTest
{
    private MainPage _mainPage;

    [SetUp]
    public void PagesSetUp()
    {
        _mainPage = new MainPage();
    }

    [Test]
    public void CheckIfEpamLogoDisplayed()
    {
        var isLogoDisplayed = _mainPage.IsEpamLogoDisplayed();
        Assert.That(isLogoDisplayed, Is.True,
            $"'Epam logo' is not displayed on the page '{MainPage.GetPageUrl()}'");
    }
}