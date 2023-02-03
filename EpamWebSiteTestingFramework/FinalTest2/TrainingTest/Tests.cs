using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Tests;

namespace FinalTest2.TrainingTest;

[TestFixture]
public class Tests : BaseTest
{
    private MainTrainingPage _mainTrainingPage;

    [SetUp]
    public void InitPages()
    {
        _mainTrainingPage = new();
        _mainTrainingPage.OpenMainPage();
        Waiter.WaitForPageLoading();
    }

    [Test]
    [TestCase(Languages.English, "en")]
    [TestCase(Languages.Русский, "ru")]
    [TestCase(Languages.Українська, "ua")]
    public void CheckIfPossibleToChangeLanguage(Languages language, string lang)
    {
        _mainTrainingPage.ChangeLanguage(language);
        var isLanguageWasChosen = _mainTrainingPage.IsNeededLanguageChosen(lang);
        Assert.That(isLanguageWasChosen, Is.True, "{0} is not chosen", language.ToString());
    }
}