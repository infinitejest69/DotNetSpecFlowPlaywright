Feature: BBC Sports

@web
Scenario: Check Sports F1
	Given i navigate to "https://www.bbc.co.uk/sport"
	When i click menu "Formula 1"
	When i click menu "Standings"
	Then i see current formula 1 driver table