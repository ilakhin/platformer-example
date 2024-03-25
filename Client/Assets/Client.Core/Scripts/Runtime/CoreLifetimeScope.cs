using Client.Core.Attachments;
using Client.Core.Modifiers;
using Client.Foundation;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Client.Core
{
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

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<CoreEntryPoint>();
            builder.RegisterInstance(_config);

            builder.RegisterComponent(_cameraProvider).As<ICamera>();
            builder.RegisterComponent(_player).As<IPlayer>();
            builder.RegisterComponent(_regionController);

            builder.Register<IStateMachine, StateMachine>(Lifetime.Singleton);
            builder.Register<IState, StartState>(Lifetime.Transient);
            builder.Register<IState, MainState>(Lifetime.Transient);
            builder.Register<IState, StopState>(Lifetime.Transient);

            builder.Register<IAttachmentManager, AttachmentManager>(Lifetime.Singleton);
            builder.Register<ICoinManager, CoinManager>(Lifetime.Singleton);
            builder.Register<ICollisionManager, CollisionManager>(Lifetime.Singleton);
            builder.Register<IModifierManager, ModifierManager>(Lifetime.Singleton);

            builder.Register<IAttachmentHandler, CoinAttachmentHandler>(Lifetime.Singleton);
            builder.Register<IAttachmentHandler, FlyAttachmentHandler>(Lifetime.Singleton);
            builder.Register<IAttachmentHandler, VelocityAttachmentHandler>(Lifetime.Singleton);
        }
    }
}
