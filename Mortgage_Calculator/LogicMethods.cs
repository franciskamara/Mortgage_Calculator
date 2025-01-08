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
            double totalAmount = input.Amount - input.Deposit;
            double monthlyRepayment;
            double monthlyRepaymentPlus3;

            List<PaymentItem> repayments = new();
            List<double> monthlyRepayments = new();

            if (t == MortgageType.Interest_Only)
            {
                //Interest-only monthly repayment calculation
                //Interest-Only = ((Amount x InterestRate) / 12months) x totalMonths
                monthlyRepayment = ((totalAmount * interestRateDecimal) / CONSTANTS.MONTHS_OF_YEAR);

                monthlyRepaymentPlus3 = ((totalAmount * (interestRateDecimal + CONSTANTS.INTEREST_RATE)) / CONSTANTS.MONTHS_OF_YEAR);
            }
            else
            {
                //Standard monthly repayment calculation
                //Repayment = Amount x (monthlyInterestRate x (1 + (monthlyInterestRate * 12months))) /
                // (1 + (monthlyInterestRate x totalMonths) - 1)
                double monthlyInterestRate = interestRateDecimal / CONSTANTS.MONTHS_OF_YEAR;//Monthly interest rate calc
                monthlyRepayment = totalAmount * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, totalMonths)) /
                                  (Math.Pow(1 + monthlyInterestRate, totalMonths) - 1);

                double monthlyInterestRatePlus3 = (interestRateDecimal + CONSTANTS.INTEREST_RATE) / CONSTANTS.MONTHS_OF_YEAR;//Monthly interest rate calc
                monthlyRepaymentPlus3 = totalAmount * (monthlyInterestRatePlus3 * Math.Pow(1 + monthlyInterestRatePlus3, totalMonths)) /
                                  (Math.Pow(1 + monthlyInterestRatePlus3, totalMonths) - 1);

            }

            double remainingAmount;
            double inputAmount = input.Amount;
            double inputDeposit = input.Deposit;
            if (t == MortgageType.Standard)
                remainingAmount = monthlyRepayment * totalMonths;//Total amount is remaining amount
            else
                remainingAmount = inputAmount - inputDeposit;

            //Total Repayment balance 
            repayments.Add(new PaymentItem
            {
                Date = DateTime.Now,
                RemainingAmount = remainingAmount,
            });
            
            //Loop months after first month
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
            //double potentialIncreaseRepayment = monthlyRepaymentPlus3 * CONSTANTS.INTEREST_RATE;//Monthly repayment if interest rises by 3%
            double roundedValue = Math.Round(monthlyRepaymentPlus3, 2);
            Results results = new()//New results local variable
            {
                WarningIndicator = $"Hello, be aware that if your monthly repayment where to increase by 3% at anytime, it will be £{roundedValue:N2}.\n " +
                                   $"Ensure you have enough for this change.",
                MonthlyRepayments = monthlyRepayments,
                PaymentItems = repayments
            };

            //if calculation is standard, add made up paymentitem to paymentitems list with value 0 and month 12
            PaymentItem finalPaymentItem = results.PaymentItems.LastOrDefault();
            if (t == MortgageType.Standard)
            {
                // Get the year from the last payment item
                if (finalPaymentItem != null)
                {
                    repayments.Add(new PaymentItem
                    {
                        Amount = 0,
                        Date = new DateTime(finalPaymentItem.Date.Year, 12, 31), // December 31 of the same year
                        RemainingAmount = 0
                    });
                }
            }
            else
            {
                repayments.Add(new PaymentItem
                {
                    Amount = 0,
                    Date = new DateTime(finalPaymentItem.Date.Year, 12, 31),
                    RemainingAmount = inputAmount - inputDeposit
                });
            }

            return results;//Return results
        }
    }
}