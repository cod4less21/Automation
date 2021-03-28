Feature: Google



@mytag
Scenario: Google Test
	Given I am on google page
		And I click 'I agree' button
	When I enter 'Automation' in the search box
	Then I should see my search result 'Automation'
	