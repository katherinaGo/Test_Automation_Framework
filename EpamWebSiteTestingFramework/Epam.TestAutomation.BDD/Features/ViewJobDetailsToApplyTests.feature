Feature: ViewJobDetailsToApplyTests
As a user interested in EPAM Company
I want to be able to open the main page using given link
I want to be able to search job by different keywords and be able to apply

    @smoke
    Scenario Outline: Check if 'Apply' form is displayed and possible to fill it in
        Given The job listings page is opened
        And Enter job name <keyword>
        When The result that contains the <keyword> is displayed on the page and by pressing button the job details page is opened
        Then Entering <name>, <surname>, <email> to apply the job is available

        Examples:
          | keyword | name   | surname   | email              |
          | xamarin | Kylian | Mbappé    | Mbappe@gmail.com   |
          | devops  | Renee  | Zellweger | Zelveger@gmail.com |