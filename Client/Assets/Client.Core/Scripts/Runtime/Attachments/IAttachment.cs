namespace Client.Core.Attachments
{
    // Прикрепление (монеты, бонусы).
    public interface IAttachment
    {
        void Handle(IAttachmentManager attachmentManager);
    }
}
