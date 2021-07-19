Feature: BBC News

@web
Scenario: Check i can access my local News
	Given i navigate to "https://www.bbc.co.uk/news"
	When i click menu "Scotland"
	And i click menu "Edinburgh, Fife & East"
	Then i see stories for "Edinburgh, Fife & East Scotland"