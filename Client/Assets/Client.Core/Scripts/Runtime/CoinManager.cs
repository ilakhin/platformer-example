using JetBrains.Annotations;
using R3;

namespace Client.Core
{
    // Используется для менеджмента монет.
    [UsedImplicitly]
    public sealed class CoinManager : ICoinManager
    {
        ReactiveProperty<int> ICoinManager.Coins
        {
            get;
        } = new();
    }
}
