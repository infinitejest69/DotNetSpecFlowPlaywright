Feature: BBC Weather

@web
Scenario: Check My Local Weather
	Given i navigate to "https://www.bbc.co.uk/weather"
	When i input the location "Glasgow, Glasgow City"
	And click search
	Then i see current weather for "Glasgow, Glasgow City"

@web @Fail
Scenario: XFail Check My Local Weather
	Given i navigate to "https://www.bbc.co.uk/weather"
	When i input the location "Glasgow, Glasgow City"
	And click search
	Then i see current weather for "Edinburgh"