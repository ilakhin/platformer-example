using JetBrains.Annotations;
using UnityEngine;

namespace Client.Foundation
{
    // Используется для трекинга целевой позиции.
    [DisallowMultipleComponent]
    public sealed class TransformFollower : MonoBehaviour
    {
        [SerializeField]
        public Transform _targetTransform;

        private bool TryGetNextPosition(out Vector3 position)
        {
            if (_targetTransform == null)
            {
                position = default;

                return false;
            }

            var sourcePosition = transform.position;
            var targetPosition = _targetTransform.position;

            position = new Vector3(targetPosition.x, targetPosition.y, sourcePosition.z);

            return true;
        }

        [UsedImplicitly]
        private void Update()
        {
            if (TryGetNextPosition(out var position))
            {
                transform.position = position;
            }
        }
    }
}
