using JetBrains.Annotations;
using R3;

namespace Client.Core
{
    [UsedImplicitly]
    public sealed class CoinManager : ICoinManager
    {
        ReactiveProperty<int> ICoinManager.Coins
        {
            get;
        } = new();
    }
}
