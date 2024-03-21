using System.Collections.Generic;
using Client.Foundation;
using JetBrains.Annotations;

namespace Client.Core
{
    [UsedImplicitly]
    internal sealed class StateMachine : StateMachine<IState>
    {
        public StateMachine(IEnumerable<IState> states)
            : base(states)
        {
        }
    }
}
