namespace Mortgage_Calculator
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

                UserInput inputs = new();//Call UserInput class properties
                MortgageType type = new();//Call MortgageType class properties

                inputs.Amount = UIMethods.LoanAmountInput();//Assign Amount input to userInput property: Amount

                inputs.Term = UIMethods.TermTime();//Assign Term input to userInput property: Term

                inputs.Type = UIMethods.SelectMortgageType();// Assign MortgageType input to userInput property: Type

                inputs.InterestRatePercentage = (double)UIMethods.InterestRateInput();//Assign Interest Rate input to userInput property: Interest Rate

                inputs.Deposit = UIMethods.DepositInput();//Assign Deposit input to userInput property: Deposit

                //--------------
                Results resultSet = LogicMethod.CalculateRepayments(inputs, type);
                UIMethods.ClearConsole();
                Console.WriteLine($"Total amount: £{resultSet.TotalAmount:N2}\n");
                Console.WriteLine("Monthly repayments \n_____________");
                //for (int i = 0; i < 1; i++)
                //{
                //    Console.WriteLine($"{resultSet.PaymentItems[i].Year}: £{resultSet.PaymentItems[i].Amount:N2} ");
                //}
                for (int i = 0; i <= resultSet.PaymentItems.Count; i++)//Print monthly repayments from list
                {
                    Console.WriteLine($"{resultSet.PaymentItems[i].Year}: £{resultSet.PaymentItems[i].Amount} ");
                }

                Console.WriteLine($"Total months: {resultSet.MonthlyRepayments.Count}");//Print total number of payments
                Console.WriteLine($"{resultSet.WarningIndicator}");
            }
            if (mortgageCalcSelect == CONSTANTS.OPTION_CALCULATE_AND_COMPARE_MORTGAGES)
            {
                UIMethods.PrintCalculateDoubleMortgageMessage();

                UserInput firstInputs = new();
                UserInput secondInputs = new();
                MortgageType type = new();

                UIMethods.MessageFirstInputSet();//First set of inputs notification 

                firstInputs.Amount = UIMethods.LoanAmountInput();

                firstInputs.Term = UIMethods.TermTime();

                firstInputs.Type = UIMethods.SelectMortgageType();

                firstInputs.InterestRatePercentage = (double)UIMethods.InterestRateInput();

                firstInputs.Deposit = UIMethods.DepositInput();

                //------------
                UIMethods.MessageSecondInputSet();//Second set of inputs notification 

                secondInputs.Amount = UIMethods.LoanAmountInput();

                secondInputs.Term = UIMethods.TermTime();

                secondInputs.Type = UIMethods.SelectMortgageType();

                secondInputs.InterestRatePercentage = (double)UIMethods.InterestRateInput();

                secondInputs.Deposit = UIMethods.DepositInput();

                //-----------
                UIMethods.ClearConsole();
                Console.WriteLine("First mortgage\n");
                Results firstResultSet = LogicMethod.CalculateRepayments(firstInputs, type);
                //UIMethods.ClearConsole();
                Console.WriteLine($"Total amount: £{firstResultSet.TotalAmount:N2}\n");
                Console.WriteLine("Monthly repayments \n-------------");
                for (int i = 0; i < 1; i++)
                {
                    Console.WriteLine($"{firstResultSet.PaymentItems[i].Year}: £{firstResultSet.PaymentItems[i].Amount:N2} ");
                }
                //for (int i = 0; i <= firstResultSet.PaymentItems.Count; i++)//Print monthly repayments from list
                //{
                //    Console.WriteLine($"{firstResultSet.PaymentItems[i].Year}: £{firstResultSet.PaymentItems[i].Amount} ");
                //}

                Console.WriteLine($"Total months: {firstResultSet.MonthlyRepayments.Count}");//Print total number of payments
                Console.WriteLine($"{firstResultSet.WarningIndicator}");

                //------------
                Console.WriteLine("\nSecond mortgage\n");
                Results secondResultSet = LogicMethod.CalculateRepayments(secondInputs, type);
                //UIMethods.ClearConsole();
                Console.WriteLine($"Total amount: £{secondResultSet.TotalAmount:N2}\n");
                Console.WriteLine("Monthly repayments \n-------------");
                for (int i = 0; i < 1; i++)
                {
                    Console.WriteLine($"{secondResultSet.PaymentItems[i].Year}: £{secondResultSet.PaymentItems[i].Amount:N2} ");
                }
                //for (int i = 0; i <= secondResultSet.PaymentItems.Count; i++)//Print monthly repayments from list
                //{
                //    Console.WriteLine($"{secondResultSet.PaymentItems[i].Year}: £{secondResultSet.PaymentItems[i].Amount} ");
                //}

                Console.WriteLine($"Total months: {secondResultSet.MonthlyRepayments.Count}");//Print total number of payments
                Console.WriteLine($"{secondResultSet.WarningIndicator}");
            }


        }
    }
}