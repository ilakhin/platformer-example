namespace Client.Core.Attachments
{
    public interface IAttachmentManager
    {
        void Handle<T>(T attachment)
            where T : class, IAttachment;
    }
}
