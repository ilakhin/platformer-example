using Client.Foundation;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Client.Core
{
    [UsedImplicitly]
    public sealed class StartState : IState
    {
        private readonly Player _player;
        private readonly HudView _hudView;
        private readonly HudViewModel _hudViewModel;
        private readonly ICollisionManager _collisionManager;

        public StartState(Player player, HudView hudView, HudViewModel hudViewModel, ICollisionManager collisionManager)
        {
            _player = player;
            _hudView = hudView;
            _hudViewModel = hudViewModel;
            _collisionManager = collisionManager;
        }

        async UniTask IState.OnEnterAsync(IStateMachine stateMachine)
        {
            _player.Initialize(_collisionManager);
            _hudView.Initialize(_hudViewModel);

            await stateMachine.ChangeAsync<MainState>();
        }

        UniTask IState.OnExitAsync(IStateMachine stateMachine)
        {
            return UniTask.CompletedTask;
        }
    }
}
