using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.DriverCreator;
using Epam.TestAutomation.Core.Elements;
using Epam.TestAutomation.Core.Utils;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.PageObjects.Pages;

public class JobDetailsPage : BasePage
{
    private JobSearchResultPage _resultPage;

    public TextInput FirstName => new(By.Id(
        "_content_epam_en_careers_job-listings_job_jcr_content_right-container_form_constructor_applicantFirstName"));

    public TextInput LastName => new(By.Id(
        "_content_epam_en_careers_job-listings_job_jcr_content_right-container_form_constructor_applicantLastName"));

    public TextInput Email => new(By.Id(
        "_content_epam_en_careers_job-listings_job_jcr_content_right-container_form_constructor_applicantEmail"));

    public override bool IsOpened()
    {
        throw new NotImplementedException();
    }

    public override void OpenUrl()
    {
    }

    public JobDetailsPage()
    {
        _resultPage = new();
    }

    public JobDetailsPage ClickViewAndApplyOnFirstJobToOpenDetails()
    {
        _resultPage.ViewAndApply.Click();
        Waiter.WaitForCondition(FirstName.IsElementEnabled);
        Browser.Driver.ScrollToElement(Email.Element);
        return new JobDetailsPage();
    }

    public void FillUpTheMandatoryFields(string name, string lastName, string email)
    {
        FillTheField(FirstName, name);
        FillTheField(LastName, lastName);
        FillTheField(Email, email);
    }

    public bool CheckIfMandatoryFieldsAreFilled(string name, string lastName, string email)
    {
        return IsFieldContainsEnteredText(FirstName, name) && IsFieldContainsEnteredText(LastName, lastName) &&
               IsFieldContainsEnteredText(Email, email);
    }

    private void FillTheField(BaseElement textField, string inputValue)
    {
        textField.SendKeys(inputValue);
    }

    private bool IsFieldContainsEnteredText(BaseElement textField, string value)
    {
        return textField.GetTextFromAttribute("value").Equals(value);
    }
}