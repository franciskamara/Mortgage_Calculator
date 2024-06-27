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
                monthlyRepayment = ((totalAmount * interestRateDecimal) / CONSTANTS.TWELVE_MONTHS) * totalMonths;
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

            for (int month = 1; month <= totalMonths; month++)//Loop as many times as totalMonths
            {
                remainingAmount -= monthlyRepayment;//Remaining (Total) amount after every monthly loop
                double amountIncreaseByThreePercent = monthlyRepayment * CONSTANTS.THREE_PERCENT;//Monthly repayment if interest rises by 3%

                monthlyRepayments.Add(monthlyRepayment);
                repayments.Add(new PaymentItem
                {
                    Amount = monthlyRepayment,
                    Year = DateTime.Now.AddMonths(month - 1),
                    RemainingAmount = remainingAmount,
                    WarningIndicator = $"Hello: Be aware that if your montlhy repayment where to increase by 3% at anytime, it will be {amountIncreaseByThreePercent}." +
                    $"Ensure you have enoough for this change."
                }); //Add data to Payment Items class
            }

            Results results = new()//New results local variable
            {
                MonthlyRepayments = monthlyRepayments,
                _paymentItems = repayments
            };

            return results;//Return results

        }
    }
}