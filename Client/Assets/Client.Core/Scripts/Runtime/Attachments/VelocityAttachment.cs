using UnityEngine;

namespace Client.Core.Attachments
{
    // Прикрепление - модификатор скорости (ускорение / замедление).
    [CreateAssetMenu]
    public sealed class VelocityAttachment : Attachment, IAttachment
    {
        [SerializeField]
        private string _id;

        [SerializeField]
        private float _duration;

        [SerializeField]
        private float _ratio;

        public string Id => _id;

        public float Duration => _duration;

        public float Ratio => _ratio;
    }
}
