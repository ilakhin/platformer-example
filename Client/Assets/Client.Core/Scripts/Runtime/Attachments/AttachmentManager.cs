using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Client.Core.Attachments
{
    // Используется для менеджмента прикреплений.
    [UsedImplicitly]
    public sealed class AttachmentManager : IAttachmentManager
    {
        private readonly Dictionary<Type, IAttachmentHandler> _attachmentHandlers;

        public AttachmentManager(IEnumerable<IAttachmentHandler> attachmentHandlers)
        {
            _attachmentHandlers = attachmentHandlers.ToDictionary(static handler => handler.AttachmentType);
        }

        void IAttachmentManager.Handle(IAttachment attachment)
        {
            var attachmentType = attachment.GetType();

            if (_attachmentHandlers.TryGetValue(attachmentType, out var attachmentHandler))
            {
                attachmentHandler.Handle(attachment);
            }
        }
    }
}
