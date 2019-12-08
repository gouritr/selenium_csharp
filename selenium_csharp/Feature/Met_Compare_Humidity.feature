Feature: Compare Humidity for a given location and for given times
	
	
@mytag
Scenario: Able to compare humidity between today and tomorrow
	Given user has selected a location 'Reading'
    When user has chosen time next 1 hour from now 
    Then the humidity for next day for the same chosen hour