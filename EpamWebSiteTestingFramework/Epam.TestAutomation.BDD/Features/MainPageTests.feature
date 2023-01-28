Feature: MainPageTests
As a user interested in EPAM Company
I want to be able to open the main page using given link

    @smoke
    Scenario: Check if main page is opened
        Given The main page is opened
        When Page is loaded
        Then The loaded webpage has the same url

    @smoke
    Scenario: Check if Engineer Banner is displayed on the main page
        Given The main page is opened
        When Page is loaded
        Then The Engineer banner is displayed on the main page
        
    @smoke
    Scenario: Check if slider displayed on the main page
        Given The main page is opened
        When Page is loaded
        Then The slider is displayed on the main page
    