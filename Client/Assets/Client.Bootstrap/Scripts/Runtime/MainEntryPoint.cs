using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine.AddressableAssets;
using VContainer.Unity;

namespace Client.Bootstrap
{
    // Точка входа Main.
    [UsedImplicitly]
    public sealed class MainEntryPoint : IAsyncStartable
    {
        private readonly MainConfig _config;

        public MainEntryPoint(MainConfig config)
        {
            _config = config;
        }

        async UniTask IAsyncStartable.StartAsync(CancellationToken cancellationToken)
        {
            await Addressables.InitializeAsync().ToUniTask(cancellationToken: cancellationToken);
            await _config.CoreSceneReference.LoadSceneAsync().ToUniTask(cancellationToken: cancellationToken);
        }
    }
}
