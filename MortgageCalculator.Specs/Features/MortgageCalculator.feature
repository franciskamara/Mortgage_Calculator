Feature: MortgageCalculator

@mytag
Scenario Outline: Loan amount input and Deposit validation 
	Given page object is initialized
	When the loan amount input is <loanAmount>
	And the deposit amount is <depAmount>
	Then the error message contains <firstAction> 
	And the error message contains <secAction>
	Examples:  
		| loanAmount | depAmount | firstAction                                                | secAction                                                  |
		| 0          | 0         | Amount needs to be more than 0.                            | Deposit amount cannot be more or equal to the Loan amount. |
		| -1         | 1         | Amount needs to be more than 0.                            | Deposit amount cannot be more or equal to the Loan amount. |
		| 1          | 0         |                                                            |                                                            |
		| 1          | 1         | Deposit amount cannot be more or equal to the Loan amount. |                                                            |
		| 2          | 1         |                                                            |                                                            |
  
Scenario Outline: Loan amount input validation
	Given page object is initialized
	When the loan amount input is <loanAmount>
	Then the error message contains <action>
	Examples: 
		| loanAmount | action                          |
		| -1         | Amount needs to be more than 0. |
		| 0          | Amount needs to be more than 0. |
		| 1          |                                 |
		| 1          | Amount needs to be more than 0. |
    
Scenario Outline: Term input validation 
	Given page object is initialized
	When the term input is <input>
	Then the error message contains <action>
	Examples: 
		| input | action                                              |
		| 0     | Term input is required and needs to be more than 0. |
		| -1    | Term input is required and needs to be more than 0. |
		| 1     |                                                     |
		| 41    | Term input cannot be more than 40 years.            |
		| 40    | Term input cannot be more than 40 years.            |
  
Scenario Outline: Mortgage Type selection validation 
  	Given page object is initialized
  	When the type is <type>
	Then the system displays for Mortgage Type <action>
	Examples: 
		| type     | action |
		| None     |        |
		| Standard | valid  |
		| Interest | valid  |
  
Scenario Outline: Interest Rate input validation NEGATIVE
	Given page object is initialized
	When the interest rate is <intRate>
	Then the error message contains <action>
	Examples: 
		| intRate | action                                       |
		| 0       | Interest rate input needs to be more than 0. |
		| -1      | Interest rate input needs to be more than 0. | 
  
#Scenario: Interest Rate input validation NO INPUT 
#	Given page object is initialized
#	When the interest rate is empty
#	Then the error message contains "Interest rate needs to be more than 0."
	
Scenario: Interest Rate input validation EXCEEDING 100%
	Given page object is initialized
	When the interest rate is 101
	Then the error message contains Interest rate input cannot exceed 100%.

  
Scenario Outline: Deposit input validation 
	Given page object is initialized
	When the loan amount input is <lAmount>
	And the deposit amount is <dAmount>
	Then the error message contains Cannot have a negative Deposit amount.
	Examples: 
			| lAmount | dAmount |
			| 1       | -1      | 