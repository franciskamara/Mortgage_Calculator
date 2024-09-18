using System;
namespace Mortgage_Calculator
{
    public class LogicMethod
    {
        public static Results CalculateRepayments(UserInput input, MortgageType t)
        {
            double interestRateDecimal = input.InterestRatePercentage / 100;
            int termYears = input.Term;
            int totalMonths = termYears * CONSTANTS.MONTHS_OF_YEAR;//Total months of Loan term calc
            double deposit = input.Deposit;
            double totalAmount = input.Amount - deposit;
            double monthlyRepayment;


            List<PaymentItem> repayments = new();
            List<double> monthlyRepayments = new();

            if (t == MortgageType.Interest_Only)
            {
                //Interest-only monthly repayment calculation
                //Interest-Only = ((Amount x InterestRate) / 12months) x totalMonths
                monthlyRepayment = ((totalAmount * interestRateDecimal) / CONSTANTS.MONTHS_OF_YEAR);
            }
            else
            {
                //Standard repayment calculation
                //Repayment = Amount x (monthlyInterestRate x (1 + (monthlyInterestRate * 12months))) /
                // (1 + (monthlyInterestRate x totalMonths) - 1)
                double monthlyInterestRate = interestRateDecimal / CONSTANTS.MONTHS_OF_YEAR;//Monthly interest rate calc
                monthlyRepayment = totalAmount * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, totalMonths)) /
                                  (Math.Pow(1 + monthlyInterestRate, totalMonths) - 1);
            }

            double remainingAmount = 0;

            if (t == MortgageType.Standard)
                remainingAmount = monthlyRepayment * totalMonths;//Total amount is remaining amount
            else
                remainingAmount = input.Amount - input.Deposit;

            repayments.Add(new PaymentItem
            {
                Date = DateTime.Now,
                RemainingAmount = remainingAmount,
            });
            for (int month = 1; month <= totalMonths; month++)//Loop as many times as totalMonths (x totalMonths)
            {
                if (t == MortgageType.Standard)
                {
                    remainingAmount -= monthlyRepayment;//Remaining (Total) amount after every monthly loop
                }

                monthlyRepayments.Add(monthlyRepayment);
                repayments.Add(new PaymentItem
                {
                    Amount = monthlyRepayment,
                    Date = DateTime.Now.AddMonths(month),
                    RemainingAmount = remainingAmount,
                }); //Add data to Payment Items class
            }
            double potentialIncreaseRepayment = monthlyRepayment * CONSTANTS.INTEREST_RATE;//Monthly repayment if interest rises by 3%
            double roundedValue = Math.Round(potentialIncreaseRepayment, 2);
            Results results = new()//New results local variable
            {
                WarningIndicator = $"Hello, be aware that if your monthly repayment where to increase by 3% at anytime, it will be £{roundedValue:N2}. Ensure you have enough for this change.",
                MonthlyRepayments = monthlyRepayments,
                PaymentItems = repayments
            };

            return results;//Return results

        }
    }
}