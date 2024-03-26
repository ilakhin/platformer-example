using JetBrains.Annotations;

namespace Client.Core.Attachments
{
    [UsedImplicitly]
    public sealed class CoinAttachmentHandler : IAttachmentHandler<CoinAttachment>
    {
        private readonly ICoinManager _coinManager;

        public CoinAttachmentHandler(ICoinManager coinManager)
        {
            _coinManager = coinManager;
        }

        void IAttachmentHandler<CoinAttachment>.Handle(CoinAttachment attachment)
        {
            _coinManager.Coins.Value += attachment.Coins;
        }
    }
}
