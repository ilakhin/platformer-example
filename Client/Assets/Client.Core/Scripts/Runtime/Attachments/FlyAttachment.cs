using UnityEngine;

namespace Client.Core.Attachments
{
    [CreateAssetMenu]
    public sealed class FlyAttachment : Attachment, IAttachment
    {
        [SerializeField]
        private float _duration;

        public float Duration => _duration;

        void IAttachment.Handle(IAttachmentManager attachmentManager)
        {
            attachmentManager.Handle(this);
        }
    }
}
