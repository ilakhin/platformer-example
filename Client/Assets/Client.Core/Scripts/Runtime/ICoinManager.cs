namespace Client.Core
{
    public interface ICoinManager
    {
        int Coins
        {
            get;
        }

        void AddCoins(int coins);
    }
}
