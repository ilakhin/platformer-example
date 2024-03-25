using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Client.Bootstrap
{
    [DisallowMultipleComponent]
    public sealed class MainLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private MainConfig _config;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<MainEntryPoint>();
            builder.RegisterInstance(_config);
        }
    }
}
