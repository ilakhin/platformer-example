using UnityEngine;

namespace Client.Core.Attachments
{
    [CreateAssetMenu]
    public sealed class CoinAttachment : Attachment, IAttachment
    {
        [SerializeField]
        private int _coins;

        public int Coins => _coins;

        void IAttachment.Handle(IAttachmentManager attachmentManager)
        {
            attachmentManager.Handle(this);
        }
    }
}
