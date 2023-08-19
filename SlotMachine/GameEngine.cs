namespace SlotMachine
{
    public class GameEngine
    {
        private decimal m_CurrentBalance;

        public GameEngine(decimal deposit)
        {
            m_CurrentBalance = deposit;
        }

        public void Run()
        {
            while (m_CurrentBalance > 0)
            {
                var currentStake = GetStake();
                var result = SlotManager.Spin(currentStake);

                m_CurrentBalance = m_CurrentBalance - currentStake + result;
                Console.WriteLine($"Current balance is: {m_CurrentBalance}");
            }

            Console.WriteLine("Game over!");
        }

        private decimal GetStake()
        {
            Console.WriteLine();
            Console.WriteLine("Enter stake amount:");
            var isValueParsedSuccessfully = decimal.TryParse(Console.ReadLine(), out var stake);
            while (!isValueParsedSuccessfully || stake < 0 || stake > m_CurrentBalance)
            {
                Console.WriteLine($"Invalid value. Please enter a positive number up to your current balance ({m_CurrentBalance}):");
                isValueParsedSuccessfully = decimal.TryParse(Console.ReadLine(), out stake);
            }

            return stake;
        }
    }
}
