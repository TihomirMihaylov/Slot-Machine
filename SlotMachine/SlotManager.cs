using SlotMachine.Interfaces;
using SlotMachine.Models;

namespace SlotMachine
{
    public class SlotManager : ISlotManager
    {
        private const int Rows = 4;
        private const int Columns = 3;

        private static readonly Dictionary<char, double> PayoutMapping = new()
        {
            { Configuration.AppleSymbol, Configuration.AppleCoefficient },
            { Configuration.BananaSymbol, Configuration.BananaCoefficient },
            { Configuration.PineappleSymbol, Configuration.PineappleCoefficient },
            { Configuration.WildcardSymbol, Configuration.WildcardCoefficient }
        };

        public decimal Spin(decimal stake)
        {
            var matrix = new Symbol [Rows, Columns];

            FillMatrixWithRandomValues(matrix);
            PrintMatrix(matrix);

            var winnings = CalculateWinnings(matrix, stake);

            Console.WriteLine($"You have won: {Math.Round(winnings, 2)}");
            return winnings;
        }

        private static void FillMatrixWithRandomValues(Symbol[,] matrix)
        {
            for (var row = 0; row < Rows; row++)
            {
                for (var col = 0; col < Columns; col++)
                {
                    matrix[row, col] = GetRandomResult();
                }
            }
        }

        private static Symbol GetRandomResult()
        {
            var randomGenerator = new Random();

            var rndChar = randomGenerator.NextDouble() switch
            {
                < Configuration.ProbabilityOfA => Configuration.AppleSymbol,
                < Configuration.ProbabilityOfA + Configuration.ProbabilityOfB => Configuration.BananaSymbol,
                < Configuration.ProbabilityOfA + Configuration.ProbabilityOfB + Configuration.ProbabilityOfP => Configuration.PineappleSymbol,
                _ => Configuration.WildcardSymbol
            };

            return SymbolFactory.GetSymbol(rndChar);
        }

        private static void PrintMatrix(Symbol[,] matrix)
        {
            Console.Write(Environment.NewLine);
            for (var row = 0; row < Rows; row++)
            {
                for (var col = 0; col < Columns; col++)
                {
                    Console.Write(matrix[row, col].GetSymbol());
                }

                Console.Write(Environment.NewLine);
            }

            Console.Write(Environment.NewLine);
        }

        //method is made public to be unit tested
        public static decimal CalculateWinnings(Symbol[,] matrix, decimal stake)
        {
            var coefficient = 0.0;
            for (var row = 0; row < Rows; row++)
            {
                var valuesOnCurrentRow = new char[Columns];
                for (var col = 0; col < Columns; col++)
                {
                    valuesOnCurrentRow[col] = matrix[row, col].GetSymbol();
                }

                var isCurrentLineAWinner = CheckCurrentLine(valuesOnCurrentRow);
                if (isCurrentLineAWinner)
                {
                    foreach (var symbol in valuesOnCurrentRow)
                    {
                        coefficient += PayoutMapping[symbol];
                    }
                }
            }

            return Math.Round((decimal)coefficient * stake, 2, MidpointRounding.ToEven);
        }

        private static bool CheckCurrentLine(IEnumerable<char> values)
        {
            var valuesWithoutWildcard = values.Where(c => c != Configuration.WildcardSymbol).ToArray();
            if (valuesWithoutWildcard.Length < Columns - 1)
            {
                return true; //line contains only wildcard symbols or wildcard symbols + 1 other
            }

            var firstChar = valuesWithoutWildcard[0];
            for (var i = 1; i < valuesWithoutWildcard.Length; i++)
            {
                if (valuesWithoutWildcard[i] != firstChar)
                {
                    return false; //Array contains a different character
                }
            }

            return true; //All characters are equal
        }
    }
}
