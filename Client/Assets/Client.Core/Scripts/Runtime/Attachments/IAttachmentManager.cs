namespace Client.Core.Attachments
{
    // Используется для менеджмента прикреплений.
    public interface IAttachmentManager
    {
        void Handle(IAttachment attachment);
    }
}
