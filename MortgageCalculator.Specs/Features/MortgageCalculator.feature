Feature: MortgageCalculator

@mytag
#Scenario: Add two numbers
#	Given the first number is 50
#	And the second number is 70
#	When the two numbers are added
#	Then the result should be 120
	
Scenario Outline: Loan amount input validation 
	Given the user is on the Loan amount field
	When the user enters a loan amount of <loanAmount>
	And the deposit amount is <depAmount>
	And all other inputs are valid
	Then the system displays <firstAction>
	And additionally <secAction>
	Examples:  
		| loanAmount | depAmount | firstAction                                        | secAction                                          |
		| 0          | 0         | errorMessage: amount input                         | errorMessage: Deposit has be less than Loan amount |
		| -1         | 1         | errorMessage: amount input                         | errorMessage: Deposit has be less than Loan amount |
		|            | 0         | errorMessage: amount input                         | errorMessage: Deposit has be less than Loan amount |
		| 1          | 0         | Result display                                     | none                                               |
		| 1          | 1         | errorMessage: Deposit has be less than Loan amount | none                                               |
		| 2          | 1         | Result display                                     | none                                               |
  
Scenario Outline: Term input validation 
	Given the user is on the term field 
	When the user enters a term input of <input>
	And all other inputs are valid
	Then the system displays <action>
	Examples: 
		| input | action                             |
		| 0     | errorMessage: Term input is needed |
		|       | errorMessage: Term input is needed |
		| -1    | errorMessage: Term input is needed |
		| 1     | Result display                     |
  
Scenario Outline: Mortgage Type selection validation 
  	Given the user is on the Mortgage Type selection field 
  	When the user make a selection <selection>
	And all other inputs are valid
	Then the system displays <action>
	Examples: 
		| selection                | action                                     |
		| --Select mortgage type-- | errorMessage: Select a valid mortgage Type |
		| Standard                 | Result display                             |
		| Interest_Only            | Result display                             |
  
Scenario Outline: Interest Rate input validation 
	Given the user is on the Interest Rate field 
	When the user enters an interest rate of <intRate>
	And all other inputs are valid 
	Then the system dislays <action>
	Examples: 
		| intRate | action                                      |
		| 0       | errorMessage: Interest rare input is needed |
		| -1      | errorMessage: Interest rare input is needed | 
  
Scenario Outline: Deposit input validation 
	Given the user is on the Deposit input field 
	When the enters a deposit amount of -1
	And all other inputs are valid 
	Then the system displays an error message  