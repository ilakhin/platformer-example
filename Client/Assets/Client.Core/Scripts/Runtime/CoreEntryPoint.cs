using System.Threading;
using Client.Foundation;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using VContainer.Unity;

namespace Client.Core
{
    [UsedImplicitly]
    internal sealed class CoreEntryPoint : IAsyncStartable
    {
        private readonly IStateMachine _stateMachine;

        public CoreEntryPoint(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        async UniTask IAsyncStartable.StartAsync(CancellationToken cancellation)
        {
            await _stateMachine.ChangeAsync<StartState>();
        }
    }
}
