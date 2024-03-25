using Client.Foundation;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Client.Core
{
    [UsedImplicitly]
    public sealed class StopState : IState
    {
        UniTask IState.OnEnterAsync(IStateMachine stateMachine)
        {
            return UniTask.CompletedTask;
        }

        UniTask IState.OnExitAsync(IStateMachine stateMachine)
        {
            return UniTask.CompletedTask;
        }
    }
}
