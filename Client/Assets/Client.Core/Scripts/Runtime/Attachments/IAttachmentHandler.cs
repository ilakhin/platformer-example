using System;

namespace Client.Core.Attachments
{
    // Обработчик прикрепления. Используется для обработки при начислении.
    public interface IAttachmentHandler
    {
        Type AttachmentType
        {
            get;
        }

        void Handle(IAttachment attachment);
    }
}
