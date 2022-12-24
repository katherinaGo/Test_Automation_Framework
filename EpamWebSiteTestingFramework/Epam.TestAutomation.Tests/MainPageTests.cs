using Epam.TestAutomation.Pages.PageObjects.Pages;

namespace Epam.TestAutomation.Tests;

public class MainPageTests : BaseTest
{
    private MainPage MainPage { get; set; }

    [SetUp]
    public void SetUp()
    {
        MainPage = new MainPage();
    }

    [Test]
    public void CheckIfMainPageIsOpenedTest()
    {
        var isPageOpened = MainPage.IsOpened();
        Assert.That(isPageOpened, Is.True, "Main page is not opened.");
    }
}