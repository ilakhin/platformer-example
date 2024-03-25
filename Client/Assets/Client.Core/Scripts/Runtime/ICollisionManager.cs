namespace Client.Core
{
    public interface ICollisionManager
    {
        void OnTriggerEnter(IPlayer player, ITrigger trigger);
    }
}
