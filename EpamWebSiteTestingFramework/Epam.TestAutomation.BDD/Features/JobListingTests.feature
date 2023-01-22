Feature: JobListingTests
As a user interested in EPAM Company
I want to be able to open the main page using given link
I want to be able to search job by different keywords

    @smoke
    Scenario Outline: Check search results related To Professions
        Given The application url
        And The job listings page is opened
        When Enter job name <keyword>
        Then The result that contains the <keyword> is displayed on the page

        Examples:
          | keyword |
          | qa      |
          | ios     |
          | android |
          | .net    |

    @smoke
    Scenario Outline: Check that error message displayed when nothing was Found
        Given The application url
        And The job listings page is opened
        When Enter job and location names <keyword1>, <keyword2>
        Then The error message is displayed on the page that nothing was found

        Examples:
          | keyword1    | keyword2   |
          | invalidInfo | Berlin     |
          | Test        | Birmingham |