Feature: UpdatingPlayerInfo
	#Due to incompatibility between specflow .netcore, these acceptance tests will require considerable work before functioning and are on hold
	

@mytag
Scenario: Adding a new player
	Given I make a call to the API requesting to add a new player
	And I have entered a new username and password
	When I make the request
	Then the player is added to the league

Scenario: Adding a new game 
	Given I make a call to the API with data 
	When I add details of a game 
	Then the winning player increments their win total by one
	And the losing player increments their losss total by one

