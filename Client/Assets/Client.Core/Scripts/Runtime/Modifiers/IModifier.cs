namespace Client.Core.Modifiers
{
    public interface IModifier
    {
        string Id
        {
            get;
        }

        float Duration
        {
            get;
        }

        void Activate();

        void Deactivate();
    }
}
