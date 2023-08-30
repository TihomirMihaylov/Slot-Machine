namespace SlotMachine.Models
{
    public abstract class Symbol
    {
        private readonly char _symbol;

        protected Symbol(char symbol)
        {
            _symbol = symbol;
        }

        public char GetSymbol() => _symbol;
    }
}
