using System;
namespace Mortgage_Calculator
{
	public class LogicMethod
	{
        public static Results CalcResults(UserInput input, MortgageType t)
        {
            var totalAmount = input.Amount;
            var interestRate = input.InterestRate;
            var termYears = input.Term;

            if(t == MortgageType.Interest_Only)
            {
                //todo implement first the one thats easer
                var interestPayment = ((totalAmount * interestRate) / CONSTANTS.ONE_YEAR) * termYears;

                
            }
            if(t == MortgageType.Repayment)
            {
                //implement other calc
                var fullRepayment = totalAmount * (interestRate * CONSTANTS.ONE_YEAR) /
                    1 - (1 + (interestRate * CONSTANTS.ONE_YEAR)) - CONSTANTS.ONE_YEAR * termYears;
            }

            return 
            //TODO Implement

            //Interest-only payment calc
            //((Amount x Interest) / 12months) x term years

            //Repayment calc
            //Amount x (InterestRate x 12months) /
            // 1 - (1 + (InterestRate x 12months)) - 12months x (term years)
        }
    }
}

