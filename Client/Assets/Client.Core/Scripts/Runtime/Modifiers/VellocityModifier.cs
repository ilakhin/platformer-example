namespace Client.Core.Modifiers
{
    // Модификатор скорости.
    public sealed class VellocityModifier : IModifier
    {
        private readonly string _id;
        private readonly float _duration;
        private readonly float _ratio;
        private readonly IPlayer _player;

        public VellocityModifier(string id, float duration, float ratio, IPlayer player)
        {
            _id = id;
            _duration = duration;
            _ratio = ratio;
            _player = player;
        }

        string IModifier.Id => _id;

        float IModifier.Duration => _duration;

        void IModifier.Activate()
        {
            _player.RunningVelocityRatio *= _ratio;
        }

        void IModifier.Deactivate()
        {
            _player.RunningVelocityRatio /= _ratio;
        }
    }
}
