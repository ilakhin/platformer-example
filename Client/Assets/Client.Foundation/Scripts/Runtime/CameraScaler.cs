using UnityEngine;

namespace Client.Foundation
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Camera))]
    public sealed class CameraScaler : MonoBehaviour
    {
        [SerializeField]
        private float _widthSize;

        [Range(0f, 1f)]
        [SerializeField]
        private float _matchWidthOrHeight;

        private Camera _camera;
        private float _heightSize;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
            _heightSize = _camera.orthographicSize;
        }

        private void Update()
        {
            if (!_camera.orthographic)
            {
                return;
            }

            var orthographicSize = Mathf.Lerp( _widthSize / _camera.aspect, _heightSize, _matchWidthOrHeight);

            _camera.orthographicSize = orthographicSize;
        }
    }
}
