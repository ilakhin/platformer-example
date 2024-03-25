using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Client.Core.Attachments
{
    [UsedImplicitly]
    public sealed class AttachmentManager : IAttachmentManager
    {
        private readonly IAttachmentHandler[] _attachmentHandlers;

        public AttachmentManager(IEnumerable<IAttachmentHandler> attachmentHandlers)
        {
            _attachmentHandlers = attachmentHandlers.ToArray();
        }

        void IAttachmentManager.Handle<T>(T attachment)
        {
            foreach (var baseAttachmentHandler in _attachmentHandlers)
            {
                if (baseAttachmentHandler is IAttachmentHandler<T> derivedAttachmentHandler)
                {
                    derivedAttachmentHandler.Handle(attachment);
                }
            }
        }
    }
}
