using UnityEngine;

namespace Client.Core
{
    [DisallowMultipleComponent]
    public sealed class Region : MonoBehaviour
    {
        [SerializeField]
        private float _width;

        public float Width => _width;

        private void OnEnable()
        {
            var items = GetComponentsInChildren<IItem>(true);

            foreach (var item in items)
            {
                item.SetActive(true);
            }
        }
    }
}
