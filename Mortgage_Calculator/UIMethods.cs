namespace Mortgage_Calculator;

public class UIMethods
{
    /// <summary>
    /// Print Mortgage Calculator Welcome message
    /// </summary>
    public static void PrintWelcomeMessage()
    {
        Console.WriteLine(" Welcome to the Mortgage Calculator ");
        Console.WriteLine("++++++++++++++++++++++++++++++++++++");
        Console.WriteLine();
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
            int userCalculatorSelect = default;

            if (int.TryParse(Console.ReadLine(), out userCalculatorSelect))
            {
                if (userCalculatorSelect == CONSTANTS.OPTION_CALCULATE_SINGLE_MORTGAGE ||
                    userCalculatorSelect == CONSTANTS.OPTION_CALCULATE_AND_COMPARE_TWO_MORTGAGES)
                {
                    Console.Clear();
                    return userCalculatorSelect;
                }
            }
            InvalidInputMessage();
        }
    }

    /// <summary>
    /// User made invalid input 
    /// </summary>
    public static void InvalidInputMessage()
    {
        Console.WriteLine("Invalid input. Please try again");
        Console.Clear();
    }

    /// <summary>
    /// Message notifying user of selection: Single calculator
    /// </summary>
    public static void PrintCalculateSingleMortgageMessage()
    {
        Console.Clear();
        Console.WriteLine("Calculate a single mortgage");
    }

    /// <summary>
    /// Message notifying user of selection: Double calculator
    /// </summary>
    public static void PrintCalculateDoubleMortgageMessage()
    {
        Console.Clear();
        Console.WriteLine("Calculate and compare two mortgages");
    }
}