using System;
namespace Mortgage_Calculator
{
	public class LogicMethod
	{
        public static Results CalcResults(UserInput input, MortgageType t)
        {

            if(t == MortgageType.Repayment)
            {
                //todo implement first the one thats easer
            }
            else
            {
                //implement other calc
            }

            //TODO Implement

            //Interest-only payment calc
            //((Amount x Interest) / 12months) x term years

            //Repayment calc
            //Amount x (InterestRate x 12months) /
            // 1 - (1 + (InterestRate x 12months)) - 12months x (term years)
        }
    }
}

