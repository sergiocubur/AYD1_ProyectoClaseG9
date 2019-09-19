Feature: Login

@mytag
Scenario: Ok Login
	Given Lunch navigator Chrome
	And Navigate to localhost 
	When Enter code user 2626
	When enter Password 2628
	And Click on Login Button
	Then Result should be visible home page
