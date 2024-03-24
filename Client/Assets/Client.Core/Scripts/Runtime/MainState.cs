using Client.Foundation;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace Client.Core
{
    [UsedImplicitly]
    internal sealed class MainState : IState
    {
        private readonly Player _player;

        public MainState(Player player)
        {
            _player = player;
        }
        
        UniTask IState.OnEnterAsync(IStateMachine stateMachine)
        {
            Debug.Log($"Enter to {GetType().Name}");

            _player.Running = true;

            return UniTask.CompletedTask;
        }

        UniTask IState.OnExitAsync(IStateMachine stateMachine)
        {
            Debug.Log($"Exit from {GetType().Name}");

            _player.Running = false;

            return UniTask.CompletedTask;
        }
    }
}
