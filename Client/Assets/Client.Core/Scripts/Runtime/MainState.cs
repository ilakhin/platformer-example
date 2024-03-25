using Client.Core.Modifiers;
using Client.Foundation;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine.InputSystem;

namespace Client.Core
{
    [UsedImplicitly]
    public sealed class MainState : IState
    {
        private readonly InputAction _jumpAction;
        private readonly IPlayer _player;
        private readonly IModifierManager _modifierManager;

        public MainState(CoreConfig coreConfig, IPlayer player, IModifierManager modifierManager)
        {
            _jumpAction = coreConfig.JumpAction;
            _jumpAction.canceled += JumpAction_Canceled;
            _jumpAction.started += JumpAction_Started;

            _player = player;
            _modifierManager = modifierManager;
        }

        private void JumpAction_Canceled(InputAction.CallbackContext context)
        {
            _player.Jumping = false;
        }

        private void JumpAction_Started(InputAction.CallbackContext context)
        {
            _player.Jumping = true;
        }

        UniTask IState.OnEnterAsync(IStateMachine stateMachine)
        {
            _jumpAction.Enable();
            _player.Running = true;

            return UniTask.CompletedTask;
        }

        UniTask IState.OnExitAsync(IStateMachine stateMachine)
        {
            _jumpAction.Disable();
            _player.Running = false;
            _modifierManager.Clear();

            return UniTask.CompletedTask;
        }
    }
}
