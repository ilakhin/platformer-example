using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Client.Core
{
    // Конфигурация InputManager.
    [Serializable]
    public sealed class InputManagerConfig
    {
        [SerializeField]
        private InputAction _jumpAction;

        public InputAction JumpAction => _jumpAction;
    }
}
