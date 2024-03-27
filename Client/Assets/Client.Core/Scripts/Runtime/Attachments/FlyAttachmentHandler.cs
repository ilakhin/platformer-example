using Client.Core.Modifiers;
using JetBrains.Annotations;

namespace Client.Core.Attachments
{
    // Обработчик прикрепления - полет.
    [UsedImplicitly]
    public sealed class FlyAttachmentHandler : IAttachmentHandler<FlyAttachment>
    {
        private readonly IModifierManager _modifierManager;
        private readonly IPlayer _player;

        public FlyAttachmentHandler(IModifierManager modifierManager, IPlayer player)
        {
            _modifierManager = modifierManager;
            _player = player;
        }

        void IAttachmentHandler<FlyAttachment>.Handle(FlyAttachment attachment)
        {
            var modifier = new FlyModifier(attachment.Id, attachment.Duration, _player);

            _modifierManager.AddModifier(modifier);
        }
    }
}
