namespace SlotMachine
{
    public static class SlotManager
    {
        private const int Rows = 4;
        private const int Columns = 3;

        private const char AppleSymbol = 'A';
        private const char BananaSymbol = 'B';
        private const char PineappleSymbol = 'P';
        private const char WildcardSymbol = '*';

        private const double ProbabilityOfA = 0.45;
        private const double ProbabilityOfB = 0.35;
        private const double ProbabilityOfP = 0.15;
        //Based on the above values the Probability Of Wildcard is 0.05;

        private static readonly Dictionary<char, double> PayoutMapping = new()
        {
            { AppleSymbol, 0.4 },
            { BananaSymbol, 0.6 },
            { PineappleSymbol, 0.8 },
            { WildcardSymbol, 0 }
        };

        //method is made public to be unit tested
        public static decimal Spin(decimal stake)
        {
            var matrix = new char [Rows, Columns];

            FillMatrixWithRandomValues(matrix);
            PrintMatrix(matrix);

            var winnings = CalculateWinnings(matrix, stake);

            Console.WriteLine($"You have won: {winnings}");
            return winnings;
        }

        private static void FillMatrixWithRandomValues(char[,] matrix)
        {
            for (var row = 0; row < Rows; row++)
            {
                for (var col = 0; col < Columns; col++)
                {
                    matrix[row, col] = GetRandomResult();
                }
            }
        }

        private static char GetRandomResult()
        {
            var randomGenerator = new Random();
            return randomGenerator.NextDouble() switch
            {
                < ProbabilityOfA => AppleSymbol,
                < ProbabilityOfA + ProbabilityOfB => BananaSymbol,
                < ProbabilityOfA + ProbabilityOfB + ProbabilityOfP => PineappleSymbol,
                _ => WildcardSymbol
            };
        }

        private static void PrintMatrix(char[,] matrix)
        {
            Console.Write(Environment.NewLine);
            for (var row = 0; row < Rows; row++)
            {
                for (var col = 0; col < Columns; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.Write(Environment.NewLine);
            }

            Console.Write(Environment.NewLine);
        }

        public static decimal CalculateWinnings(char[,] matrix, decimal stake)
        {
            var coefficient = 0.0;
            for (var row = 0; row < Rows; row++)
            {
                var valuesOnCurrentRow = new char[Columns];
                for (var col = 0; col < Columns; col++)
                {
                    valuesOnCurrentRow[col] = matrix[row, col];
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

            return (decimal)coefficient * stake;
        }

        private static bool CheckCurrentLine(IEnumerable<char> values)
        {
            var valuesWithoutWildcard = values.Where(c => c != WildcardSymbol).ToArray();
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
