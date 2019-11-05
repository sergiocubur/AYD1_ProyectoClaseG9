Feature: Login

@mytag
Scenario: BBD - Login 1
	Given Lunch navigator Chrome
	And Navigate to localhost 
	When Enter code user 2626
	When enter Password 2628
	And Click on Login Button
	Then Result should be visible home page

Scenario: BBD - Login 2
	Given Lunch navigator Chrome
	And Navigate to localhost 
	When Enter error code user 2627
	And Click on Login Button
	Then Result should be visible login fail mesage

Scenario: BBD - Login 3
	Given Lunch navigator Chrome
	And Navigate to localhost
	When enter error Password 2627
	And Click on Login Button
	Then Result should be visible login fail mesage

Scenario: BBD - Login 4
	Given Lunch navigator Chrome
	And Navigate to localhost 
	When Enter error code user null
	When enter error Password null
	And Click on Login Button to fail
	Then Result should be visible login fail mesage

Scenario: BBD - Login 5
	Given Lunch navigator Chrome
	And Navigate to localhost
	When Enter code user  2626 
	And enter Password  2626
	And Click on Login Button
	And Navigate to root page
	Then Result should be visible home