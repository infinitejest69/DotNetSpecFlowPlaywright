Feature: BBC Iplayer

@web
Scenario: Check The Tv Guide
	Given i navigate to "https://www.bbc.co.uk/iplayer"
	When i click menu "TV Guide"
	And i click channel "bbc two"
	Then i see todays Tv Guide