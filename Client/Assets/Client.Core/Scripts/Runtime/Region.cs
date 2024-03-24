using UnityEngine;

namespace Client.Core
{
    [DisallowMultipleComponent]
    internal sealed class Region : MonoBehaviour
    {
        [SerializeField]
        private float _width;

        public float Width => _width;
    }
}
