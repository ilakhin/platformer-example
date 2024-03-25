using UnityEngine;

namespace Client.Core
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Camera))]
    public sealed class CameraProvider : MonoBehaviour, ICamera
    {
        private Camera _camera;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        void ICamera.SetWidthSize(float size)
        {
            _camera.orthographicSize = size / _camera.aspect;
        }
    }
}
