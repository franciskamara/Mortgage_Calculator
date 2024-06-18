using System;
namespace Mortgage_Calculator
{
    public class LogicMethod
    {
        public static Results CalculateRepayments(UserInput input, MortgageType t)
        {
            int totalAmount = input.Amount;
            double interestRateDecimal = input.InterestRatePercentage / 100;
            int termYears = input.Term;
            List<double> repayments = new List<double>();

            if (t == MortgageType.Interest_Only)
            {
                //Interest-only payment calc
                //((Amount x InterestRate) / 12months) x totalMonths

                double monthlyRepayment = (totalAmount * interestRateDecimal) / CONSTANTS.TWELVE_MONTHS;//Monthly repayment calc
                int totalMonths = termYears * CONSTANTS.TWELVE_MONTHS;//Total months of Loan term calc
                for (int monthly = 1; monthly <= totalMonths; monthly++)//Loop as many times totalMonths
                {
                    repayments.Add(monthlyRepayment);//List the month's repayment 
                }
            }
            else
            {
                double monthlyInterestRate = interestRateDecimal / CONSTANTS.TWELVE_MONTHS;//Monthly interest rate calc
                int totalMonths = termYears * CONSTANTS.TWELVE_MONTHS;//Total months of repayment calc
                double monthlyRepayment = totalAmount * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, totalMonths)) /
                                  (Math.Pow(1 + monthlyInterestRate, totalMonths) - 1);
                
                for (int month = 1; month < totalMonths; month++)
                {
                    repayments.Add(monthlyRepayment);
                }

                //Repayment calc
                //Repayment = Amount x (monthlyInterestRate x (1 + (monthlyInterestRate * 12months))) /
                // (1 + (monthlyInterestRate x totalMonths) - 1)


            }
            return new Results();
            //{
            //    //todo 
            //};
            
        }
    }
}