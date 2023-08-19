namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var deposit = GetDeposit();

            var engine = new GameEngine(deposit);
            engine.Run();
        }

        private static decimal GetDeposit()
        {
            Console.WriteLine("Please deposit money you would like to play with:");
            var isValueParsedSuccessfully = decimal.TryParse(Console.ReadLine(), out var deposit);
            while (!isValueParsedSuccessfully || deposit < 0)
            {
                Console.WriteLine("Invalid value. Please enter a positive number:");
                isValueParsedSuccessfully = decimal.TryParse(Console.ReadLine(), out deposit);
            }

            return deposit;
        }
    }
}