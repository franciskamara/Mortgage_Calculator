using System.Threading.Channels;

namespace Mortgage_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIMethods.PrintWelcomeMessage();

            int userCalculatorSelect = UIMethods.SingleOrDoubleCalculatorSelection();

            if (userCalculatorSelect == CONSTANTS.OPTION_CALCULATE_SINGLE_MORTGAGE)
            {
                UIMethods.PrintCalculateSingleMortgageMessage();
            }

            if (userCalculatorSelect == CONSTANTS.OPTION_CALCULATE_AND_COMPARE_TWO_MORTGAGES)
            {
                UIMethods.PrintCalculateDoubleMortgageMessage();
            }
        }
    }
}