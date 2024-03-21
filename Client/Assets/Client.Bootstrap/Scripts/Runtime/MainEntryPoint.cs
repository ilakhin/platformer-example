using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine.AddressableAssets;
using VContainer.Unity;

namespace Client.Bootstrap
{
    [UsedImplicitly]
    internal sealed class MainEntryPoint : IAsyncStartable
    {
        private readonly MainSettings _mainSettings;

        public MainEntryPoint(MainSettings mainSettings)
        {
            _mainSettings = mainSettings;
        }

        async UniTask IAsyncStartable.StartAsync(CancellationToken cancellationToken)
        {
            await Addressables.InitializeAsync().ToUniTask(cancellationToken: cancellationToken);
            await _mainSettings.CoreSceneReference.LoadSceneAsync().ToUniTask(cancellationToken: cancellationToken);
        }
    }
}
