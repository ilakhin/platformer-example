using JetBrains.Annotations;

namespace Client.Core
{
    [UsedImplicitly]
    public sealed class CoinManager : ICoinManager
    {
        private int _coins;

        int ICoinManager.Coins => _coins;

        void ICoinManager.AddCoins(int coins)
        {
            _coins += coins;
        }
    }
}
