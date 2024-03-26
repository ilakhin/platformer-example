using UnityEngine;

namespace Client.Core
{
    [DisallowMultipleComponent]
    public sealed class Enemy : MonoBehaviour, IEnemy, ITrigger
    {
        void IEntity.SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
