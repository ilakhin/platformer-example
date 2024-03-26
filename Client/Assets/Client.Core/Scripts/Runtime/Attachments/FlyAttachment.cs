using UnityEngine;

namespace Client.Core.Attachments
{
    [CreateAssetMenu]
    public sealed class FlyAttachment : Attachment, IAttachment
    {
        [SerializeField]
        private string _id;

        [SerializeField]
        private float _duration;

        public string Id => _id;

        public float Duration => _duration;

        void IAttachment.Handle(IAttachmentManager attachmentManager)
        {
            attachmentManager.Handle(this);
        }
    }
}
