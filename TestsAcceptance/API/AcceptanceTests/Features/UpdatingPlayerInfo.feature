Feature: UpdatingPlayerInfo
	
@mytag
Scenario: Adding a new player
	Given I make a call to the API requesting to add a new player
	Then the player is added to the league

Scenario: Adding a new game 
	Given I make a call to the API with new game data 
	Then the winning player increments their win total by one
	And the losing player increments their losss total by one
