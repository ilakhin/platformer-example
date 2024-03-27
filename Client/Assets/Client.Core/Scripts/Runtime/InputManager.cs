using JetBrains.Annotations;
using UnityEngine.InputSystem;

namespace Client.Core
{
    [UsedImplicitly]
    public sealed class InputManager : IInputManager
    {
        private readonly InputManagerConfig _config;
        private readonly IPlayer _player;

        public InputManager(InputManagerConfig config, IPlayer player)
        {
            _config = config;
            _player = player;
        }

        private void JumpAction_Canceled(InputAction.CallbackContext context)
        {
            _player.Jumping = false;
        }

        private void JumpAction_Started(InputAction.CallbackContext context)
        {
            _player.Jumping = true;
        }

        void IInputManager.SetEnabled(bool enabled)
        {
            var jumpAction = _config.JumpAction;

            if (enabled)
            {
                jumpAction.canceled += JumpAction_Canceled;
                jumpAction.started += JumpAction_Started;
                jumpAction.Enable();
            }
            else
            {
                jumpAction.canceled -= JumpAction_Canceled;
                jumpAction.started -= JumpAction_Started;
                jumpAction.Disable();
            }

            _player.Running = enabled;
        }
    }
}
