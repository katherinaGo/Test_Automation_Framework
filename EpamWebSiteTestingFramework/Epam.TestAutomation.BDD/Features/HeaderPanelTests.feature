Feature: HeaderPanelTests
As a user interested in EPAM Company
I want to be able to open the main page using given link and see header on the page

    @smoke
    Scenario: Check if Epam Logo is displayed on the page
        Given The application url
        When Page is loaded
        Then The Epam Logo is displayed on the page