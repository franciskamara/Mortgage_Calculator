namespace Mortgage_Calculator;

public class UIMethods
{

    /// <summary>
    /// Print Mortgage Calculator Welcome message
    /// </summary>
    public static void PrintWelcomeMessage()
    {
        Console.WriteLine(" Welcome to the Mortgage Calculator ");
        Console.WriteLine("++++++++++++++++++++++++++++++++++++\n");
    }

    /// <summary>
    /// Ask user to select calculate type 
    /// </summary>
    /// <returns>User selection for calculator type</returns>
    public static int SingleOrDoubleCalculatorSelection()
    {
        while (true)
        {
            Console.WriteLine(
                "What do you want to do?\n1.Calculate one mortgage \n2.Calculate and compare two mortgages");
            Console.Write("Select: ");

            if (int.TryParse(Console.ReadLine(), out int userCalculatorSelect))
            {
                if (userCalculatorSelect == CONSTANTS.OPTION_CALCULATE_SINGLE_MORTGAGE ||
                    userCalculatorSelect == CONSTANTS.OPTION_CALCULATE_AND_COMPARE_TWO_MORTGAGES)
                {
                    ClearConsole();
                    return userCalculatorSelect;
                }
            }

            InvalidInputMessage();
            ClearConsole();
        }
    }

    /// <summary>
    /// User made invalid input 
    /// </summary>
    public static void InvalidInputMessage()
    {
        Console.WriteLine("Invalid input. Please try again");
        ClearConsole();
    }

    /// <summary>
    /// Clear the console 
    /// </summary>
    public static void ClearConsole()
    {
        Console.Clear();
    }

    /// <summary>
    /// Message notifying user of selection: Single calculator
    /// </summary>
    public static void PrintCalculateSingleMortgageMessage()
    {
        ClearConsole();
        Console.WriteLine("Calculate a single mortgage \n");
    }

    /// <summary>
    /// Message notifying user of selection: Double calculator
    /// </summary>
    public static void PrintCalculateDoubleMortgageMessage()
    {
        ClearConsole();
        Console.WriteLine("Calculate and compare two mortgages \n");
    }

    /// <summary>
    /// Loan/deposit amount input
    /// </summary>
    /// <returns>amount inputted</returns>
    public static double LoanAmountInput()
    {
        while (true)
        {
            //UserInput input = new();
            //double amount = input.Amount;

            try
            {
                ClearConsole();
                Console.Write("Loan amount: £");
                double amount = int.Parse(Console.ReadLine());

                return amount;
            }
            catch (Exception e)
            {
                InvalidInputMessage();
            }
        }
    }

    /// <summary>
    /// Term time of the loan
    /// </summary>
    /// <returns>Term in years</returns>
    public static int TermTime()
    {
        //UserInput input = new();
        //int term = input.Term;

        while (true)
        {
            ClearConsole();
            Console.Write("Term of agreement (In years): ");
            if (int.TryParse(Console.ReadLine(), out int term))
            {
                return term;
            }

            InvalidInputMessage();
        }
    }

    /// <summary>
    /// User selects the mortgage type 
    /// </summary>
    /// <returns>Chosen mortgage type</returns>
    public static MortgageType SelectMortgageType()
    {
        while (true)
        {
            ClearConsole();
            Console.WriteLine(
                "Select the mortgage type by number entry. " +
                "\n1. Standard: repay capital and interest. " +
                "\n2. Interest only: repay the interest. Capital paid off at the end of term. ");
            Console.Write("Select: ");
            if (int.TryParse(Console.ReadLine(), out int mortgageTypeSelect))
            {
                if (mortgageTypeSelect == CONSTANTS.OPTION_MORTGAGE_TYPE_STANDARD ||
                    mortgageTypeSelect == CONSTANTS.OPTION_MORTGAGE_TYPE_INTERESTONLY)
                {
                    if (mortgageTypeSelect == CONSTANTS.OPTION_MORTGAGE_TYPE_STANDARD)
                        return MortgageType.Standard;
                    else
                        return MortgageType.Interest_Only;
                }
                InvalidInputMessage();
            }
            InvalidInputMessage();
        }
    }

    /// <summary>
    /// Interest Rate user input, with default
    /// </summary>
    /// <returns>User input</returns>
    public static decimal InterestRateInput()
    {
        ClearConsole();
        Console.Write("Interest rate: %");
        string input = Console.ReadLine();
        decimal interest = string.IsNullOrEmpty(input) ? 5 : decimal.Parse(input);

        return interest;
    }

    /// <summary>
    /// User inputting the deposit amount (optional)
    /// </summary>
    /// <returns>Deposit input</returns>
    public static double DepositInput()
    {
        while (true)
        {
        ClearConsole();
        Console.Write("Input deposit (optional): ");
            string input = Console.ReadLine();
        if (double.TryParse(input, out double depositInput))
        {
            return depositInput;
        }
        if (string.IsNullOrWhiteSpace(input))
        {
            return 0;
        }
        InvalidInputMessage();
        }

    }

}