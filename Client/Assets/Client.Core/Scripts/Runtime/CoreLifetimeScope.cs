using Client.Core.Attachments;
using Client.Core.Modifiers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Client.Core
{
    // Корень связывания Core.
    [DisallowMultipleComponent]
    public sealed class CoreLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private CoreConfig _config;

        [SerializeField]
        private CameraProvider _cameraProvider;

        [SerializeField]
        private Player _player;

        [SerializeField]
        private RegionController _regionController;

        [SerializeField]
        private HudView _hudView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<CoreEntryPoint>();
            builder.RegisterInstance(_config);
            builder.RegisterInstance(_config.InputManagerConfig);

            builder.RegisterComponent(_cameraProvider).As<ICamera>();
            builder.RegisterComponent(_player).As<IPlayer>();
            builder.RegisterComponent(_regionController);
            builder.RegisterComponent(_hudView);

            builder.Register<IAttachmentManager, AttachmentManager>(Lifetime.Singleton);
            builder.Register<ICoinManager, CoinManager>(Lifetime.Singleton);
            builder.Register<ICollisionManager, CollisionManager>(Lifetime.Singleton);
            builder.Register<IInputManager, InputManager>(Lifetime.Singleton);
            builder.Register<IModifierManager, ModifierManager>(Lifetime.Singleton);

            builder.Register<IAttachmentHandler, CoinAttachmentHandler>(Lifetime.Singleton);
            builder.Register<IAttachmentHandler, FlyAttachmentHandler>(Lifetime.Singleton);
            builder.Register<IAttachmentHandler, VelocityAttachmentHandler>(Lifetime.Singleton);

            builder.Register<HudModel>(Lifetime.Singleton);
            builder.Register<HudViewModel>(Lifetime.Singleton);
        }
    }
}
