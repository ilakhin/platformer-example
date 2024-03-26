namespace Client.Core.Modifiers
{
    public sealed class FlyModifier : IModifier
    {
        private readonly string _id;
        private readonly float _duration;
        private readonly IPlayer _player;

        public FlyModifier(string id, float duration, IPlayer player)
        {
            _id = id;
            _duration = duration;
            _player = player;
        }

        string IModifier.Id => _id;

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
