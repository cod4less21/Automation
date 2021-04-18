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
		#And I enter UserName 'Admin' and Password 'Admin'
		And I enter the following UserName and Password:
		| UserName | Password | Email          | DOB       | Adress          |
		| Admin    | Admin    | abc@abc123.com | 27feb2012 | 19 Derby Street |
		| Odun     | Kayode   | dcb@abc123.com | 27feb2012 | 10 Derby Street |
	Then Error message is displayed 'ErrorMsg'
		And Error message 'ErrorMsg' contain 'Invalid login'
		And I quit my Browser

@mytag
Scenario Outline: EA eaapp Automation step using Examples
	Given I am on EA eaapp page
	When  I click login link text
		And I enter UserName '<UserName>' and Password '<Password>'
	Then Error message is displayed 'ErrorMsg'
		And Error message 'ErrorMsg' contain 'Invalid login'
		And I quit my Browser

	Examples: 
	| UserName | Password    |
	| Admin    | Mypassword  |
	| OdunAyo  | Mypassword2 |
	| Ibrahim  | Mypassword2 |

@Regress
Scenario: BBC Test
	Given I am on BBC website
	When I click on 'News' link
	Then I can see 'Sport' section at the buttom of the page
	And I quit my Browser

@Regress
Scenario Outline: BBC Multiple Test Example
	Given I am on BBC website
	When I click on '<link_name>' link
	Then I can see '<title>' for page
	And I quit my Browser

	Examples: 
	| link_name | title           |
	| News      | Home - BBC News |
	| Sport     | Home - BBC Sport|
	| Weather   | BBC Weather     |