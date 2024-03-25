using Client.Foundation;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Client.Core
{
    [UsedImplicitly]
    public sealed class StartState : IState
    {
        private readonly Player _player;
        private readonly ICollisionManager _collisionManager;

        public StartState(Player player, ICollisionManager collisionManager)
        {
            _player = player;
            _collisionManager = collisionManager;
        }

        async UniTask IState.OnEnterAsync(IStateMachine stateMachine)
        {
            _player.Initialize(_collisionManager);

            await stateMachine.ChangeAsync<MainState>();
        }

        UniTask IState.OnExitAsync(IStateMachine stateMachine)
        {
            return UniTask.CompletedTask;
        }
    }
}
