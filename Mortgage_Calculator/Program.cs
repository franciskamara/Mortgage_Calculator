namespace Mortgage_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int mortgageCalcSelect = UIMethods.SingleOrDoubleCalculatorSelection();

            if (mortgageCalcSelect == CONSTANTS.OPTION_CALCULATE_SINGLE_MORTGAGE)
            {

            }
            if (mortgageCalcSelect == CONSTANTS.OPTION_CALCULATE_AND_COMPARE_TWO_MORTGAGES)
            {

            }
            

        }
    }
}