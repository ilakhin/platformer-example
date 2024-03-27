using JetBrains.Annotations;
using UnityEngine;

namespace Client.Core
{
    // Сегмент игрового мира.
    [DisallowMultipleComponent]
    public sealed class Region : MonoBehaviour
    {
        [SerializeField]
        private float _width;

        public float Width => _width;

        [UsedImplicitly]
        private void OnEnable()
        {
            var entities = GetComponentsInChildren<IEntity>(true);

            foreach (var entity in entities)
            {
                entity.SetActive(true);
            }
        }
    }
}
