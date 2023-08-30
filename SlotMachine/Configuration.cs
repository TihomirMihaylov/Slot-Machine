namespace SlotMachine
{
    public abstract class Configuration //In a real app this will be the appsettings.json
    {
        public const char AppleSymbol = 'A';
        public const char BananaSymbol = 'B';
        public const char PineappleSymbol = 'P';
        public const char WildcardSymbol = '*';

        public const double ProbabilityOfA = 0.45;
        public const double ProbabilityOfB = 0.35;
        public const double ProbabilityOfP = 0.15;
        //Based on the above values the Probability Of Wildcard is 0.05;

        public const double AppleCoefficient = 0.4;
        public const double BananaCoefficient = 0.6;
        public const double PineappleCoefficient = 0.8;
        public const double WildcardCoefficient = 0;
    }
}
