using Microsoft.Extensions.DependencyInjection;
using SlotMachine.Interfaces;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Add services to DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ISlotManager, SlotManager>()
                .AddSingleton<IGameEngine>(provider =>
                {
                    var deposit = GetDeposit();
                    return new GameEngine(deposit, provider.GetRequiredService<ISlotManager>());
                })
                .BuildServiceProvider();

            var engine = serviceProvider.GetRequiredService<IGameEngine>();
            engine.Run();
        }

        private static decimal GetDeposit()
        {
            Console.WriteLine("Please deposit money you would like to play with:");
            var isValueParsedSuccessfully = decimal.TryParse(Console.ReadLine(), out var deposit);
            var roundedDeposit = Math.Round(deposit, 2, MidpointRounding.ToEven);
            while (!isValueParsedSuccessfully || roundedDeposit <= 0)
            {
                Console.WriteLine("Invalid value. Please enter a positive number:");
                isValueParsedSuccessfully = decimal.TryParse(Console.ReadLine(), out deposit);
                roundedDeposit = Math.Round(deposit, 2, MidpointRounding.ToEven);
            }

            return roundedDeposit;
        }
    }
}