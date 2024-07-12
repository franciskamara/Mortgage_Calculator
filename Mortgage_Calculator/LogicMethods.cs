using System;
namespace Mortgage_Calculator
{
    public class LogicMethod
    {
        public static Results CalculateRepayments(UserInput input, MortgageType t)
        {
            double totalAmount = input.Amount;
            double interestRateDecimal = input.InterestRatePercentage / 100;
            int termYears = input.Term;
            int totalMonths = termYears * CONSTANTS.TWELVE_MONTHS;//Total months of Loan term calc
            double monthlyRepayment;

            List<PaymentItem> repayments = new();
            List<double> monthlyRepayments = new();

            if (t == MortgageType.Interest_Only)
            {
                //Interest-only monthly repayment calculation
                //Interest-Only = ((Amount x InterestRate) / 12months) x totalMonths
                monthlyRepayment = ((totalAmount * interestRateDecimal) / CONSTANTS.TWELVE_MONTHS);
            }
            else
            {
                //Standard repayment calculation
                //Repayment = Amount x (monthlyInterestRate x (1 + (monthlyInterestRate * 12months))) /
                // (1 + (monthlyInterestRate x totalMonths) - 1)
                double monthlyInterestRate = interestRateDecimal / CONSTANTS.TWELVE_MONTHS;//Monthly interest rate calc
                monthlyRepayment = totalAmount * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, totalMonths)) /
                                  (Math.Pow(1 + monthlyInterestRate, totalMonths) - 1);
            }

            double remainingAmount = totalAmount;//Total amount is remaining amount 

            for (int month = 1; month <= totalMonths; month++)//Loop as many times as totalMonths (x totalMonths)
            {
                remainingAmount -= monthlyRepayment;//Remaining (Total) amount after every monthly loop

                monthlyRepayments.Add(monthlyRepayment);
                repayments.Add(new PaymentItem
                {
                    Amount = monthlyRepayment,
                    Year = DateTime.Now.AddMonths(month - 1),
                    RemainingAmount = remainingAmount,
                }); //Add data to Payment Items class
            }
            double potentialIncreaseRepayment = monthlyRepayment * CONSTANTS.THREE_PERCENT;//Monthly repayment if interest rises by 3%
            double roundedValue = Math.Round(potentialIncreaseRepayment, 2);
            Results results = new()//New results local variable
            {
                WarningIndicator = $"Hello, be aware that if your monthly repayment where to increase by 3% at anytime, it will be £{roundedValue:N2}. Ensure you have enoough for this change.",
                MonthlyRepayments = monthlyRepayments,
                PaymentItems = repayments
            };

            return results;//Return results

        }
    }
}