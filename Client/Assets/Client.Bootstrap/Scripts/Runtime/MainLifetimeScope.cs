using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Client.Bootstrap
{
    [DisallowMultipleComponent]
    internal sealed class MainLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private MainSettings _mainSettings;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<MainEntryPoint>();
            builder.RegisterInstance(_mainSettings);
        }
    }
}
