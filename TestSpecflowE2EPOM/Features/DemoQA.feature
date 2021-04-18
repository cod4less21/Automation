Feature: DemoQA

@mytag
Scenario: DemoQA test
	Given I am on DemoQA page
		And I click 'Elements'
		And I wait for 3 seconds
		And I click 'Text Box' on element page
		And I wait for 3 seconds
	When I enter full Name 'Joseph'
		And I enter email 'abc@abc.com'
		And I wait for 3 seconds
	Then Full name is 'Joseph'