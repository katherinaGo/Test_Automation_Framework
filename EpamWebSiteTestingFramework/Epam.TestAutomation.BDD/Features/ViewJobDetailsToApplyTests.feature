Feature: ViewJobDetailsToApplyTests
As a user interested in EPAM Company
I want to open the main page using given link
To be able to search job by different keywords

    @smoke
    Scenario Outline: Check if 'Apply' form is displayed and possible to edit fields
        Given The job listings page is opened
        And Enter job name <keyword>
        When The result that contains the <keyword> is displayed on the result page
        And By pressing 'ViewAndApply' button the job details page is opened
        Then Entering <testValue> to apply the job is available

        Examples:
          | keyword | testValue |
          | xamarin | test      |
          | devops  | hello     |