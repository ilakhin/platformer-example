using UnityEngine;

namespace Client.Core.Attachments
{
    [CreateAssetMenu]
    public sealed class VelocityAttachment : Attachment, IAttachment
    {
        [SerializeField]
        private float _duration;

        [SerializeField]
        private float _ratio;

        public float Duration => _duration;

        public float Ratio => _ratio;

        void IAttachment.Handle(IAttachmentManager attachmentManager)
        {
            attachmentManager.Handle(this);
        }
    }
}
