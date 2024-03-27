using Client.Core.Modifiers;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer.Unity;

namespace Client.Core
{
    [UsedImplicitly]
    public sealed class CoreEntryPoint : IStartable, ITickable
    {
        private readonly CoreConfig _config;
        private readonly ICollisionManager _collisionManager;
        private readonly IModifierManager _modifierManager;
        private readonly ICamera _camera;
        private readonly IPlayer _player;
        private readonly HudView _hudView;
        private readonly HudViewModel _hudViewModel;

        public CoreEntryPoint(CoreConfig config, ICollisionManager collisionManager, IModifierManager modifierManager, ICamera camera, IPlayer player, HudView hudView, HudViewModel hudViewModel)
        {
            _config = config;
            _collisionManager = collisionManager;
            _modifierManager = modifierManager;
            _camera = camera;
            _player = player;
            _hudView = hudView;
            _hudViewModel = hudViewModel;
        }

        private void JumpAction_Canceled(InputAction.CallbackContext context)
        {
            _player.Jumping = false;
        }

        private void JumpAction_Started(InputAction.CallbackContext context)
        {
            _player.Jumping = true;
        }

        void IStartable.Start()
        {
            // TODO: Данные фрагменты должны лежать на уровне фабрики.
            ((Player)_player).Initialize(_collisionManager);
            _hudView.Initialize(_hudViewModel);

            _camera.SetWidthSize(_config.CameraSize);
            _player.Running = true;

            var jumpAction = _config.JumpAction;

            jumpAction.canceled += JumpAction_Canceled;
            jumpAction.started += JumpAction_Started;
            jumpAction.Enable();
        }

        void ITickable.Tick()
        {
            _modifierManager.Update(Time.time);
        }
    }
}
