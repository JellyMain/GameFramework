namespace Core.Economy
{
    public interface IEconomyManager
    {
        public int Coins { get; }
        public int Gems { get; }

        public void AddCoins(int amount);
        public void AddGems(int amount);
        public bool TrySpendCoins(int amount);
        public bool TrySpendGems(int amount);
        public void Init();
    }
}
