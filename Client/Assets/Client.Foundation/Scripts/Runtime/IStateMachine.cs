using System;
using Cysharp.Threading.Tasks;

namespace Client.Foundation
{
    public interface IStateMachine
    {
        UniTask ChangeAsync(Type stateType);
    }
}
