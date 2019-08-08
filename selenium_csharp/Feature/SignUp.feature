Feature: Signup into SmartCompare
	

@mytag
Scenario:Valid SignUp|
	Given Uesr is on SignUp Page
	When User Enters valid credentials as below
	| Username | Email         | Password | PasswordConfirmation |
	| abc      | abc@gmail.com | 123456   | 123456               |
	Then User should be able to LoginSuccessfully


Scenario: User signing not allowed with blank vlaues
	Given User is on SignUp page
	When User tries to signwith Blank fields
	| Username | Email | Password | PasswordConfirmation |
	|          |       |          |                      |	
	Then User should not be able to SignUp Successfully with msg This field is required


	Scenario: Invalid signup when password confirmation doesnt match password
		Given Uesr is on SignUp Page
		When User Enters valid credentials as below
		| Username | Email         | Password | PasswordConfirmation |
		| abc      | abc@gmail.com | 123456   | 1234567               |
		Then User should not be able to SignUp Successfully with msg Passwords must match