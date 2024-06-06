namespace Mortgage_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var x = new UserInput();
            x.Amount = 20000;

            var z = LogicMethod.CalcResults(x);

        }
    }
}