namespace Client.Core.Modifiers
{
    public interface IModifier
    {
        float Duration
        {
            get;
        }

        void Activate();

        void Deactivate();
    }
}
