using Cysharp.Threading.Tasks;

namespace Client.Foundation
{
    public interface IState
    {
        UniTask OnEnterAsync(IStateMachine stateMachine);

        UniTask OnExitAsync(IStateMachine stateMachine);
    }
}
