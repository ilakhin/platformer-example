using UnityEngine;
using UnityEngine.InputSystem;

namespace Client.Core
{
    [CreateAssetMenu]
    public sealed class CoreConfig : ScriptableObject
    {
        [SerializeField]
        private float _cameraSize;

        [SerializeField]
        private InputAction _jumpAction;

        public float CameraSize => _cameraSize;

        public InputAction JumpAction => _jumpAction;
    }
}
