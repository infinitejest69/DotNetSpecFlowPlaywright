Feature: BBC Weather

@web
Scenario: Check My Local Weather
	Given i navigate to "https://www.bbc.co.uk/weather"
	When i input the location "Dunfermline"
	And click search
	Then i see current weather for "Dunfermline"

@web @Fail
Scenario: XFail Check My Local Weather
	Given i navigate to "https://www.bbc.co.uk/weather"
	When i input the location "Dunfermline"
	And click search
	Then i see current weather for "Edinburgh"