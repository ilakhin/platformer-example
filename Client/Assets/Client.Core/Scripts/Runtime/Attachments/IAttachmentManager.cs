namespace Client.Core.Attachments
{
    // Используется для менеджмента прикреплений.
    public interface IAttachmentManager
    {
        void Handle<T>(T attachment)
            where T : class, IAttachment;
    }
}
