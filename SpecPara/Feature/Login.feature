Feature: Login
	check if login function works

@mytag
Scenario: Login user as admin
	Given I navigate to the application
	And I enter tne username and password
	| UserName | Password |
	| admin    | admin    |
	And I click login
	Then I should see the user login into the application
