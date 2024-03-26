using R3;

namespace Client.Core
{
    public interface ICoinManager
    {
        ReactiveProperty<int> Coins
        {
            get;
        }
    }
}
