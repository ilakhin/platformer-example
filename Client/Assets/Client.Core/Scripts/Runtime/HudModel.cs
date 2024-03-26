using JetBrains.Annotations;
using R3;

namespace Client.Core
{
    [UsedImplicitly]
    public sealed class HudModel
    {
        private readonly ICoinManager _coinManager;

        public HudModel(ICoinManager coinManager)
        {
            _coinManager = coinManager;
        }

        public ReadOnlyReactiveProperty<int> Coins => _coinManager.Coins;
    }
}
