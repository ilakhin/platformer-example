using JetBrains.Annotations;
using R3;

namespace Client.Core
{
    [UsedImplicitly]
    public sealed class HudViewModel
    {
        public HudViewModel(HudModel model)
        {
            Coins.Value = model.Coins.CurrentValue;
            
            model.Coins.Subscribe(Model_Coins_OnChanged);
        }

        public ReactiveProperty<int> Coins
        {
            get;
        } = new();

        private void Model_Coins_OnChanged(int value)
        {
            Coins.Value = value;
        }
    }
}
