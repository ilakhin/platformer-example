using System;
using JetBrains.Annotations;

namespace Client.Core.Attachments
{
    // Обработчик прикрепления - монеты.
    [UsedImplicitly]
    public sealed class CoinAttachmentHandler : IAttachmentHandler
    {
        private readonly ICoinManager _coinManager;

        public CoinAttachmentHandler(ICoinManager coinManager)
        {
            _coinManager = coinManager;
        }

        private void Handle(CoinAttachment attachment)
        {
            _coinManager.Coins.Value += attachment.Coins;
        }

        Type IAttachmentHandler.AttachmentType => typeof(CoinAttachment);

        void IAttachmentHandler.Handle(IAttachment attachment)
        {
            Handle((CoinAttachment)attachment);
        }
    }
}
