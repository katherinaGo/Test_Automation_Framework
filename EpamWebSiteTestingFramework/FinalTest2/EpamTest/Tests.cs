using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Tests;

namespace FinalTest2.EpamTest;

[TestFixture]
public class Tests : BaseTest
{
    private CareerPage _careerPage;

    [SetUp]
    public void InitPages()
    {
        _careerPage = new();
        Waiter.WaitForPageLoading();
    }

    [Test]
    public void CheckIfLearnMoreButtonDisplayedOnCareersPage()
    {
        _careerPage.OpenCareerPage();
        var isButtonDisplayed = _careerPage.CheckIfLearnMoreButtonIsDisplayedOnPage();
        Assert.That(isButtonDisplayed, Is.True, "Button 'Learn More' is not displayed in the Career Page");
    }
}