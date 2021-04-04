Feature: Google

#Background: 
#	Given I am on google page


@mytag
Scenario: Google Test
	Given I am on google page
	When I click 'I agree' button
		And I enter 'Automation' in the search box
	Then I should see my search result 'Automation'
		And I quit my Browser


@mytag
Scenario: Calculator test
	Given My firstnumber is 50
		And My second number is 70
	When I add both numbers together
	Then My result should be 120


@mytag
Scenario: EA eaapp Automation step
	Given I am on EA eaapp page
	When  I click login link text
		And I enter UserName and Password
	Then Error message is displayed 'ErrorMsg'
		And Error message 'ErrorMsg' contain 'Invalid login'
		And I quit my Browser