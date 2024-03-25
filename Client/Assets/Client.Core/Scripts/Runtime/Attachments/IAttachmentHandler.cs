namespace Client.Core.Attachments
{
    public interface IAttachmentHandler
    {
    }

    public interface IAttachmentHandler<in T> : IAttachmentHandler
        where T : class, IAttachment
    {
        void Handle(T attachment);
    }
}
