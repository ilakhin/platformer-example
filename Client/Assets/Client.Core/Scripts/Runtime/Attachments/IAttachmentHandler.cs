namespace Client.Core.Attachments
{
    // Обработчик прикрепления. Используется для обработки при начислении.
    public interface IAttachmentHandler
    {
    }

    public interface IAttachmentHandler<in T> : IAttachmentHandler
        where T : class, IAttachment
    {
        void Handle(T attachment);
    }
}
