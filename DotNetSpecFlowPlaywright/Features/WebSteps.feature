Feature: BBC Example Web Tests:

@web
Scenario: Check i can access my local News
	Given i navigate to "https://www.bbc.co.uk/news"
	When i click news menu "Scotland"
	And i click news menu "Edinburgh, Fife & East"
	Then i see stories for "Edinburgh, Fife & East Scotland"

@web
Scenario: Check Sports F1
	Given i navigate to "https://www.bbc.co.uk/sport"
	When i click "Formula 1" from the menu
	When i click "Standings" from the submenu
	Then i see current formula 1 driver table

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

@web
Scenario: Check The Tv Guide
	Given i navigate to "https://www.bbc.co.uk/iplayer"
	When i click tv guide
	And i click channel "bbc two"
	Then i see todays Tv Guide