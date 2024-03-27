namespace Client.Core
{
    // Используется для менеджмента коллизий (Player / Trigger).
    public interface ICollisionManager
    {
        void OnTriggerEnter(IPlayer player, ITrigger trigger);
    }
}
