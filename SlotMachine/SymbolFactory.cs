using SlotMachine.Models;

namespace SlotMachine
{
    public static class SymbolFactory
    {
        public static Symbol GetSymbol(char symbol)
        {
            return symbol switch
            {
                Configuration.AppleSymbol => new AppleSymbol(),
                Configuration.BananaSymbol => new BananaSymbol(),
                Configuration.PineappleSymbol => new PineappleSymbol(),
                Configuration.WildcardSymbol => new WildcardSymbol(),
                _ => throw new ArgumentException($"Symbol '{symbol}' not recognized")
            };
        }
    }
}
