Feature: Search

@mytag
Scenario: Search whit Testing
	Given Lunch Chrome
	And Navigate to code Project
	When Click on Search our Articles 
	When Enter Testing
	And Click on Search Button
	Then Result should be visible and Browser should close
