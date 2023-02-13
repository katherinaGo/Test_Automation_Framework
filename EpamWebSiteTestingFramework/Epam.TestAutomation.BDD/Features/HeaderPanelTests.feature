Feature: HeaderPanelTests
As a user interested in EPAM Company
I want to open the main page using given link
To be able to see header on main page

    @smoke
    Scenario: Check if Epam Logo is displayed on the main page
        Given The main page is opened
        When Page is loaded
        Then The Epam Logo is displayed on the main page