Feature: Scenario Context Test

Background: 
Given Baz is 30

Scenario: 1 Set and Test Foo And Bar
When I set Foo to 10
	And I set Bar to 20 
Then Foo has been set
	And Foo is 10
	And Bar has been set
	And Bar is 20
	And Baz has been set
	And Baz is 30
	And Qux has not been set
	And Norf has not been set

Scenario: 2 Set Qux and Test Foo, Bar and Qux
When I set Qux to 45
Then Foo has not been set
	And Bar has not been set
	And Baz has been set
	And Baz is 30
	And Qux has been set
	And Qux is 45
	And Norf has not been set