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
            int totalMonths = termYears * CONSTANTS.TWELVE_MONTHS;//Total months of Loan term calc
            double monthlyRepayment;
            List<double> repayments = new();

            if (t == MortgageType.Interest_Only)
            {
                //Interest-only payment calc
                //((Amount x InterestRate) / 12months) x totalMonths
                monthlyRepayment = (totalAmount * interestRateDecimal) / CONSTANTS.TWELVE_MONTHS;//Monthly repayment calc
            }
            else
            {
                //Repayment calc
                //Repayment = Amount x (monthlyInterestRate x (1 + (monthlyInterestRate * 12months))) /
                // (1 + (monthlyInterestRate x totalMonths) - 1)
                double monthlyInterestRate = interestRateDecimal / CONSTANTS.TWELVE_MONTHS;//Monthly interest rate calc
                monthlyRepayment = totalAmount * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, totalMonths)) /
                                  (Math.Pow(1 + monthlyInterestRate, totalMonths) - 1);//Standard repayment calc       
            }
            for (int month = 1; month <= totalMonths; month++)//Loop as many times as totalMonths
            {
                repayments.Add(monthlyRepayment);//List the month repayments
            }

            return new Results();

        }
    }
}