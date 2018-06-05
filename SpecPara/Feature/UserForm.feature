Feature: UserForm
	Feature which holds all the user details entry

@mytag
Scenario: User details form entry verification
	Given I navigate to the application
	And I enter tne username and password
	| UserName | Password |
	| admin    | admin    |
	And I click login
	And  I start entering user form details like
	| Initial | FirstName | MiddleName |
	| k       | Morgan    | Zhang      |
	And I click submit button