Feature: CreateUser

@mytag
Scenario: BDD - User Add 1
	Given Lunch navigator Chrome usr
	And Navigate to localhost usr
	When Enter Code usr
	When enter password usr
	And Click on Login Button usr
	And Click on Usuario Button	usr
	And Click on Agregar Button usr
	When fill form new usr usr
	And Click on create Button usr
	Then Result should be visible usr


Scenario: BDD - User Add 2
	Given Lunch navigator Chrome usr
	And Navigate to localhost usr
	When Enter Code usr
	When enter password usr
	And Click on Login Button usr
	And Click on Usuario Button	usr
	And Click on Agregar Button usr
	When fill form new usr usr without DPI
	And Click on create Button usr
	Then Result should be visible usr
	Then Result should be visible fail message


Scenario: BDD - User Add 3
	Given Lunch navigator Chrome usr
	And Navigate to localhost usr
	When Enter Code usr
	When enter password usr
	And Click on Login Button usr
	And Click on Usuario Button	usr
	And Click on Agregar Button usr
	When fill form new usr usr without apellido
	And Click on create Button usr
	Then Result should be visible usr

Scenario: BDD - User Add 4
	Given Lunch navigator Chrome usr
	And Navigate to localhost usr
	When Enter Code usr
	When enter password usr
	And Click on Login Button usr
	And Click on Usuario Button	usr
	And Click on Agregar Button usr
	When fill form new usr usr without password
	And Click on create Button usr 
	Then Result should be visible usr
