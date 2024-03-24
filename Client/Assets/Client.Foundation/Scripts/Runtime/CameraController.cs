using UnityEngine;

namespace Client.Foundation
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Camera))]
    public sealed class CameraController : MonoBehaviour
    {
        private Camera _camera;

        [SerializeField]
        private float _velocity;
        
        [SerializeField]
        public Transform _targetTransform;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            if (_targetTransform == null)
            {
                return;
            }

            var sourcePosition = transform.position;
            var targetPosition = _targetTransform.position;

            targetPosition.z = sourcePosition.z;
            
            transform.position = Vector3.Lerp(sourcePosition, targetPosition, _velocity * Time.deltaTime);
        }
    }
}
