Feature: JobListingTests
In order to search job by different keywords
As a user interested in EPAM Company
I want to open job listings page
To be able to search jobs by keywords

    @smoke
    Scenario Outline: Check search results related To Professions
        Given The job listings page is opened
        When Enter job name <keyword>
        Then The result that contains the <keyword> is displayed on the result page

        Examples:
          | keyword |
          | qa      |
          | ios     |
          | android |
          | .net    |

    @smoke
    Scenario Outline: Check that error message displayed when nothing was Found
        Given The job listings page is opened
        When Enter job and location names <keyword1>, <keyword2> in the search panel
        Then The error message is displayed on the result page that nothing was found

        Examples:
          | keyword1    | keyword2   |
          | invalidInfo | Berlin     |
          | Test        | Birmingham |