namespace Client.Core.Attachments
{
    public interface IAttachment
    {
        void Handle(IAttachmentManager attachmentManager);
    }
}
