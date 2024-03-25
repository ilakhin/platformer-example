namespace Client.Core.Modifiers
{
    public sealed class FlyModifier : IModifier
    {
        private readonly float _duration;
        private readonly IPlayer _player;

        public FlyModifier(float duration, IPlayer player)
        {
            _duration = duration;
            _player = player;
        }

        float IModifier.Duration => _duration;

        void IModifier.Activate()
        {
            _player.Rigidbody.gravityScale *= -1f;
        }

        void IModifier.Deactivate()
        {
            _player.Rigidbody.gravityScale *= -1f;
        }
    }
}
