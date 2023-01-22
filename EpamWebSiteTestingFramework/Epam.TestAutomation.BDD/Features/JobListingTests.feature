Feature: JobListingTests
As a user interested in EPAM Company
I want to be able to open the main page using given link
I want to be able to search job by different keywords

    @smoke
    Scenario Outline: Check search results related To Professions
        Given The application url
        And The job listings page is opened
        When Enter job name <keyword>
        Then the result with searching word is displayed on the page