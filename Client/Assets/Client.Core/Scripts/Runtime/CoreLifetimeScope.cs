using Client.Foundation;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Client.Core
{
    [DisallowMultipleComponent]
    internal sealed class CoreLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<CoreEntryPoint>();

            builder.Register<IStateMachine, StateMachine>(Lifetime.Singleton);
            builder.Register<IState, StartState>(Lifetime.Transient);
            builder.Register<IState, MainState>(Lifetime.Transient);
            builder.Register<IState, StopState>(Lifetime.Transient);
        }
    }
}
