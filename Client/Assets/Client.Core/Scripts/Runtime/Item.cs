using System.Collections.Generic;
using System.Linq;
using Client.Core.Attachments;
using UnityEngine;

namespace Client.Core
{
    // Предмет (монеты, бонусы и тд).
    [DisallowMultipleComponent]
    public sealed class Item : MonoBehaviour, IItem, ITrigger
    {
        [SerializeField]
        private Attachment[] _attachments;

        IEnumerable<IAttachment> IItem.Attachments => _attachments.OfType<IAttachment>();

        void IEntity.SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
