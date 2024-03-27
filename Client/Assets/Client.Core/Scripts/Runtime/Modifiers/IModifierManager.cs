namespace Client.Core.Modifiers
{
    // Используется для менеджмента модификаций (активация / деактивация).
    public interface IModifierManager
    {
        void AddModifier(IModifier modifier);

        void Update(float currentTime);
    }
}
