using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.DriverCreator;
using Epam.TestAutomation.Core.Elements;
using Epam.TestAutomation.Core.Helper;
using Epam.TestAutomation.Core.Utils;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Pages.PageObjects.Pages;

public class JobDetailsPage : BasePage
{
    private static readonly string JobDetailsPageUrl = UiTestSettings.JobListingUrl + "/job.";

    public TextInput FirstName => new(By
        .Id(
            "_content_epam_en_careers_job-listings_job_jcr_content_right-container_form_constructor_applicantFirstName"));

    public TextInput LastName => new(By
        .Id(
            "_content_epam_en_careers_job-listings_job_jcr_content_right-container_form_constructor_applicantLastName"));

    public TextInput Email => new(By
        .Id(
            "_content_epam_en_careers_job-listings_job_jcr_content_right-container_form_constructor_applicantEmail"));

    public override bool IsOpened()
    {
        return Browser.Driver.GetUrl().Contains(JobDetailsPageUrl);
    }

    public void OpenDetailsOfFirstJob()
    {
        Waiter.WaitForCondition(FirstName.IsElementEnabled);
        Browser.Driver.ScrollToElement(Email.Element);
    }

    public void FillUpTheMandatoryFields(string testValue)
    {
        FillTheField(FirstName, testValue);
        FillTheField(LastName, testValue);
        FillTheField(Email, testValue);
    }

    public bool CheckIfMandatoryFieldsAreFilled(string testValue)
    {
        return IsFieldContainsEnteredText(FirstName, testValue) && IsFieldContainsEnteredText(LastName, testValue) &&
               IsFieldContainsEnteredText(Email, testValue);
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