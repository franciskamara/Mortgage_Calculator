Feature: MortgageCalculator

@mytag
Scenario Outline: Loan and Deposit amounts validation 
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
  
Scenario Outline: Loan amount input validation NEGATIVE 
	Given page object is initialized
	When the loan amount input is <loanAmount>
	Then the error message does not contain <action> 
	Examples: 
		| loanAmount | action                          |
		| 1          | Amount needs to be more than 0. |
		| 250000     | Amount needs to be more than 0. |

Scenario Outline: Term input validation 
	Given page object is initialized
	When the term input is <input>
	Then the error message contains <action>
	Examples: 
		| input | action                                              |
		| 0     | Term input is required and needs to be more than 0. |
		| -1    | Term input is required and needs to be more than 0. |
		| 41    | Term input cannot be more than 40 years.            |
  
Scenario Outline: Term input validation NEGATIVE 
	Given page object is initialized
	When the term input is <term>
	Then the error message does not contain <action>
	Examples: 
	| term | action                                   |
	| 1    | Term input cannot be more than 40 years. |
	| 10   | Term input cannot be more than 40 years. |
	| 25   | Term input cannot be more than 40 years. |
	| 40   | Term input cannot be more than 40 years. |
  
Scenario Outline: Mortgage Type selection validation 
  	Given page object is initialized
  	When the type is <type>
	Then the system displays for Mortgage Type <action>
	Examples: 
		| type                     | action                        |
		| None                     | Select a valid mortgage type. |
		| Standard                 | valid                         |
		| Interest                 | valid                         |
  
Scenario Outline: Interest Rate input validation 
	Given page object is initialized
	When the interest rate is <intRate>
	Then the error message contains <action>
	Examples: 
		| intRate | action                                       |
		| 0       | Interest rate input needs to be more than 0. |
		| -1      | Interest rate input needs to be more than 0. |
		| 0.1     |                                              |
		| 100     |                                              |
		| 101     | Interest rate input cannot exceed 100%.      |

Scenario Outline: Deposit input validation 
	Given page object is initialized
	When the loan amount input is <lAmount>
	And the deposit amount is <dAmount>
	Then the error message contains Cannot have a negative Deposit amount.
	Examples: 
			| lAmount | dAmount |
			| 1       | -1      | 
   
Scenario Outline: Payment Items count 
	Given page object is initialized
	When the loan amount input is <loanAmount>
	And the term input is <term>
	And the type is <mType>
	And the interest rate is <intRate>
	And the deposit amount is <depAmount>
	Then the results object contains <paymentItem> paymentItems
	Examples: 
		| loanAmount | term | mType    | intRate | depAmount | paymentItem |
		| 250000     | 1    | standard | 6.6     | 0         | 14          |
		| 250000     | 10   | interest | 6.6     | 10000     | 122         |
  
Scenario Outline: Payment Item, Final payment is 0 
	Given page object is initialized
	When the loan amount input is 100000
	And the term input is 10
	And the type is <mType>
	And the interest rate is 6.6
	And the deposit amount is 0
	Then the results object contains <finalPayment> for the final paymentItem
	Examples: 
	| mType    | finalPayment |
	| standard | 0            |
	| interest | 100000       |
  
Scenario Outline: Total Amount output 
	Given page object is initialized
	When the loan amount input is <loanAmount>
	And the term input is <term>
	And the type is <mType>
	And the interest rate is 5
	And the deposit amount is 0
	Then the results object contains total amount <totalAmount> 
	Examples: 
	  | loanAmount | term | mType    | totalAmount        |
	  | 100000     | 10   | standard | 127278.61828689057 |
	  | 100000     | 10   | interest | 49999.999999999935 |
	  | 250000     | 25   | standard | 438442.5311309876  |
	  | 250000     | 25   | interest | 312499.99999999994 |
	
Scenario Outline: Monthly Repayment count
	Given page object is initialized
	When the loan amount input is <loanAmount>
	And the term input is <term>
	And the type is <mType>
	And the interest rate is 5
	And the deposit amount is 25000
	Then the results object contains <monthlyRepayCount> repayment months
	Examples: 
	  | loanAmount | term | mType    | monthlyRepayCount |
	  | 10000      | 1    | standard | 12                |
	  | 10000      | 1    | interest | 12                |
	  | 10000      | 10   | standard | 120               |
	  | 10000      | 10   | interest | 120               |