Feature: CreateProduct

@mytag
Scenario: BDD - Product Add 1
	Given Lunch navigator Chrome pro
	And Navigate to localhost pro
	When Enter Code pro
	When enter password pro
	And Click on Login Button pro
	And Click on Product Button	pro
	And Click on Agregar Button pro
	When fill form new product	pro
	And Click on create Button pro
	Then Result should be visible pro


Scenario: BDD - Product Add 2
	Given Lunch navigator Chrome pro
	And Navigate to localhost pro
	When Enter Code pro
	When enter password pro
	And Click on Login Button pro
	And Click on Product Button	pro
	And Click on Agregar Button pro
	When fill form new product	without description pro
	And Click on create Button pro
	Then Result should be visible fail pro


Scenario: BDD - Product Add 3
	Given Lunch navigator Chrome pro
	And Navigate to localhost pro
	When Enter Code pro
	When enter password pro
	And Click on Login Button pro
	And Click on Product Button	pro
	And Click on Agregar Button pro
	When fill form new product whitout prices pro
	And Click on create Button pro
	Then Result should be visible fail pro

Scenario: BDD - Product Add 4
	Given Lunch navigator Chrome pro
	And Navigate to localhost pro
	When Enter Code pro
	When enter password pro
	And Click on Login Button pro
	And Click on Product Button	pro
	And Click on Agregar Button pro
	When fill form new product	without code pro
	And Click on create Button pro
	Then Result should be visible fail pro
