using UnityEngine;

namespace Client.Core
{
    // Противник (препятствие).
    [DisallowMultipleComponent]
    public sealed class Enemy : MonoBehaviour, IEnemy, ITrigger
    {
        void IEntity.SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
