﻿namespace Mortgage_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the mortgage calculator \n");

            int mortgageCalcSelect = UIMethods.SingleOrDoubleCalculatorSelection();

            if (mortgageCalcSelect == CONSTANTS.OPTION_CALCULATE_SINGLE_MORTGAGE)
            {
                UIMethods.PrintCalculateSingleMortgageMessage();

                UserInput inputs = new();//Call userInput class properties
                MortgageType type = new();

                inputs.Amount = UIMethods.LoanAmountInput();//Assign Amount input to userInput property: Amount

                inputs.Term = UIMethods.TermTime();//Assign Term input to userInput property: Term

                inputs.Type = UIMethods.SelectMortgageType();// Assign MortgageType input to userInput property: Type

                inputs.InterestRatePercentage = (double)UIMethods.InterestRateInput();//Assign Interest Rate input to userInput property: Interest Rate

                inputs.Deposit = UIMethods.DepositInput();//Assign Deposit input to userInput property: Deposit


                Results test = LogicMethod.CalculateRepayments(inputs, type);
                UIMethods.ClearConsole();
                Console.WriteLine($"Repayment total: £{test.TotalAmount}");
                foreach (var item in test._paymentItems)
                {
                    Console.WriteLine($"Payment Items: {test.ToString}");
                }


            }
            if (mortgageCalcSelect == CONSTANTS.OPTION_CALCULATE_AND_COMPARE_TWO_MORTGAGES)
            {
                UIMethods.PrintCalculateDoubleMortgageMessage();


            }
            

        }
    }
}