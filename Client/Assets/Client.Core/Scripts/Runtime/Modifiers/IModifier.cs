namespace Client.Core.Modifiers
{
    // Модификатор (полет, скорость).
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
