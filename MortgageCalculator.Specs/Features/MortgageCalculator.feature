Feature: MortgageCalculator

@mytag
#Scenario: Add two numbers
#	Given the first number is 50
#	And the second number is 70
#	When the two numbers are added
#	Then the result should be 120
	
Scenario Outline: Loan amount input validation 
	Given page object is initialized
	When the loan amount input is <loanAmount>
	And the deposit amount is <depAmount>
	Then the error message contains <firstAction> 
	And the error message contains <secAction>
	Examples:  
		| loanAmount | depAmount | firstAction                                                | secAction                                                  |
		| 0          | 0         | Amount needs to be more than 0.                            | Deposit amount cannot be more or equal to the Loan amount. |
		| -1         | 1         | Amount needs to be more than 0.                            | Deposit amount cannot be more or equal to the Loan amount. |
		|            | 0         | Amount needs to be more than 0.                            | Deposit amount cannot be more or equal to the Loan amount. |
		| 1          | 0         |                                                            |                                                            |
		| 1          | 1         | Deposit amount cannot be more or equal to the Loan amount. |                                                            |
		| 2          | 1         |                                                            |                                                            |
  
Scenario Outline: Term input validation 
	Given page object is initialized
	When the term input is <input>
	Then the error message contains <action>
	Examples: 
		| input | action                |
		| 0     | Term input is needed. |
		|       | Term input is needed. |
		| -1    | Term input is needed. |
		| 1     |                       |
  
Scenario Outline: Mortgage Type selection validation 
  	Given page object is initialized
  	When the type is <type>
	Then the system displays for Mortgage Type <action>
	Examples: 
		| type                     | action                       |
		| --Select mortgage type-- | Select a valid mortgage Type. |
		| Standard                 |                              |
		| Interest                 |                              |
  
Scenario Outline: Interest Rate input validation 
	Given page object is initialized
	When the interest rate is <intRate>
	Then the system displays for Interest rate <action>
	Examples: 
		| intRate | action                                 |
		| 1       |                                        |
		|         | Interest rate needs to be more than 0. |
		| 0       | Interest rate needs to be more than 0. |
		| -1      | Interest rate needs to be more than 0. | 
  
Scenario Outline: Deposit input validation 
	Given the user is on the Deposit input field 
	When the enters a deposit amount of -1
	And all other inputs are valid 
	Then the system displays an error message  