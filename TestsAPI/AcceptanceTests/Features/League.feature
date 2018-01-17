Feature: League
	#Due to incompatibility between specflow .netcore, these acceptance tests will require considerable work before functioning and are on hold

@mytag
Scenario: Viewing league table
	Given I make a call to the API requesting the top 10 players in the league
	Then the top 10 players ranked by wins are returned 
