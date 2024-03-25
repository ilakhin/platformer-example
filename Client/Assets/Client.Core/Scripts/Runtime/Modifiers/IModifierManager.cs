namespace Client.Core.Modifiers
{
    public interface IModifierManager
    {
        void AddModifier(IModifier modifier);

        void Clear();

        void Update(float currentTime);
    }
}
