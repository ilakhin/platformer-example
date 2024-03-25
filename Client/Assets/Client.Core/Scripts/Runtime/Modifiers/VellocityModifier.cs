namespace Client.Core.Modifiers
{
    public sealed class VellocityModifier : IModifier
    {
        private readonly float _duration;
        private readonly float _ratio;
        private readonly IPlayer _player;

        public VellocityModifier(float duration, float ratio, IPlayer player)
        {
            _duration = duration;
            _ratio = ratio;
            _player = player;
        }

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
