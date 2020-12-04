Feature: Product Search in Google
	

@mytag
Scenario Outline: Search in Google 
	Given user is able to navigate to google
	Then user is able to search <device>
	Examples: 
	| device |
	| iPad   |