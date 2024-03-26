using System.Threading;
using Client.Core.Modifiers;
using Client.Foundation;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using VContainer.Unity;

namespace Client.Core
{
    [UsedImplicitly]
    public sealed class CoreEntryPoint : IAsyncStartable, ITickable
    {
        private readonly CoreConfig _config;
        private readonly IStateMachine _stateMachine;
        private readonly ICamera _camera;
        private readonly IModifierManager _modifierManager;

        public CoreEntryPoint(CoreConfig config, IStateMachine stateMachine, ICamera camera, IModifierManager modifierManager)
        {
            _config = config;
            _stateMachine = stateMachine;
            _camera = camera;
            _modifierManager = modifierManager;
        }

        async UniTask IAsyncStartable.StartAsync(CancellationToken cancellation)
        {
            _camera.SetWidthSize(_config.CameraSize);

            await _stateMachine.ChangeAsync<StartState>();
        }

        void ITickable.Tick()
        {
            _modifierManager.Update(Time.time);
        }
    }
}
