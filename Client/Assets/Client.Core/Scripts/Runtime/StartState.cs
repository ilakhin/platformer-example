using Client.Foundation;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace Client.Core
{
    [UsedImplicitly]
    internal sealed class StartState : IState
    {
        async UniTask IState.OnEnterAsync(IStateMachine stateMachine)
        {
            Debug.Log($"Enter to {GetType().Name}");
            
            await stateMachine.ChangeAsync<MainState>();
        }

        UniTask IState.OnExitAsync(IStateMachine stateMachine)
        {
            Debug.Log($"Exit from {GetType().Name}");
            
            return UniTask.CompletedTask;
        }
    }
}
