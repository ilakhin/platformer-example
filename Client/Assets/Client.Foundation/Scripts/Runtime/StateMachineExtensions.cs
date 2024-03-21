using Cysharp.Threading.Tasks;

namespace Client.Foundation
{
    public static class StateMachineExtensions
    {
        public static UniTask ChangeAsync<T>(this IStateMachine stateMachine)
        {
            return stateMachine.ChangeAsync(typeof(T));
        }
    }
}
