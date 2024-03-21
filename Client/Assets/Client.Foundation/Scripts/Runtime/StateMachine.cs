using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;

namespace Client.Foundation
{
    public abstract class StateMachine<TState> : IStateMachine
        where TState : IState
    {
        private TState _currentState;
        private readonly Dictionary<Type, TState> _states;

        protected StateMachine(IEnumerable<TState> states)
        {
            _states = states.ToDictionary(static state => state.GetType());
        }

        async UniTask IStateMachine.ChangeAsync(Type stateType)
        {
            var nextState = _states[stateType];

            if (_currentState != null)
            {
                await _currentState.OnExitAsync(this);
            }

            _currentState = nextState;

            if (_currentState != null)
            {
                await _currentState.OnEnterAsync(this);
            }
        }
    }
}
