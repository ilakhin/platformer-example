using R3;

namespace Client.Core
{
    // Используется для менеджмента монет.
    public interface ICoinManager
    {
        ReactiveProperty<int> Coins
        {
            get;
        }
    }
}
