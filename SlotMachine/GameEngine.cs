using SlotMachine.Interfaces;

namespace SlotMachine
{
    public class GameEngine : IGameEngine
    {
        private decimal m_CurrentBalance;
        private readonly ISlotManager m_slotManager;

        public GameEngine(decimal deposit, ISlotManager slotManager)
        {
            m_CurrentBalance = deposit;
            m_slotManager = slotManager;
        }

        public void Run()
        {
            while (m_CurrentBalance > 0)
            {
                var currentStake = GetStake();
                var result = m_slotManager.Spin(currentStake);

                m_CurrentBalance = m_CurrentBalance - currentStake + result;
                Console.WriteLine($"Current balance is: {Math.Round(m_CurrentBalance, 2)}");
            }

            Console.WriteLine("Game over!");
        }

        private decimal GetStake()
        {
            Console.WriteLine();
            Console.WriteLine("Enter stake amount:");
            var isValueParsedSuccessfully = decimal.TryParse(Console.ReadLine(), out var stake);
            var roundedStake = Math.Round(stake, 2, MidpointRounding.ToEven);
            while (!isValueParsedSuccessfully || roundedStake <= 0 || roundedStake > m_CurrentBalance)
            {
                Console.WriteLine($"Invalid value. Please enter a positive number up to your current balance ({m_CurrentBalance}):");
                isValueParsedSuccessfully = decimal.TryParse(Console.ReadLine(), out stake);
                roundedStake = Math.Round(stake, 2, MidpointRounding.ToEven);
            }

            return roundedStake;
        }
    }
}
