using UnityEngine;

namespace Client.Core
{
    // Конфигурация Core.
    [CreateAssetMenu]
    public sealed class CoreConfig : ScriptableObject
    {
        [SerializeField]
        private float _cameraSize;

        [SerializeField]
        private InputManagerConfig _inputManagerConfig;

        public float CameraSize => _cameraSize;

        public InputManagerConfig InputManagerConfig => _inputManagerConfig;
    }
}
