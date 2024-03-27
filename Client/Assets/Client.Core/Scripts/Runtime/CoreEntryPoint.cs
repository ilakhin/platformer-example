using Client.Core.Modifiers;
using JetBrains.Annotations;
using UnityEngine;
using VContainer.Unity;

namespace Client.Core
{
    [UsedImplicitly]
    public sealed class CoreEntryPoint : IStartable, ITickable
    {
        private readonly CoreConfig _config;
        private readonly ICollisionManager _collisionManager;
        private readonly IInputManager _inputManager;
        private readonly IModifierManager _modifierManager;
        private readonly ICamera _camera;
        private readonly IPlayer _player;
        private readonly HudView _hudView;
        private readonly HudViewModel _hudViewModel;

        public CoreEntryPoint(CoreConfig config, ICollisionManager collisionManager, IInputManager inputManager, IModifierManager modifierManager, ICamera camera, IPlayer player, HudView hudView, HudViewModel hudViewModel)
        {
            _config = config;
            _collisionManager = collisionManager;
            _inputManager = inputManager;
            _modifierManager = modifierManager;
            _camera = camera;
            _player = player;
            _hudView = hudView;
            _hudViewModel = hudViewModel;
        }

        void IStartable.Start()
        {
            _camera.SetWidthSize(_config.CameraSize);
            // TODO: Вынести на уровень фабрики или выделить в отдельный контроллер.
            ((Player)_player).Initialize(_collisionManager);
            _hudView.Initialize(_hudViewModel);
            _inputManager.SetEnabled(true);
        }

        void ITickable.Tick()
        {
            _modifierManager.Update(Time.time);
        }
    }
}
