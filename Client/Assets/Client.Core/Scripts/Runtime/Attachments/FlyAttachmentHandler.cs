using System;
using Client.Core.Modifiers;
using JetBrains.Annotations;

namespace Client.Core.Attachments
{
    // Обработчик прикрепления - полет.
    [UsedImplicitly]
    public sealed class FlyAttachmentHandler : IAttachmentHandler
    {
        private readonly IModifierManager _modifierManager;
        private readonly IPlayer _player;

        public FlyAttachmentHandler(IModifierManager modifierManager, IPlayer player)
        {
            _modifierManager = modifierManager;
            _player = player;
        }

        private void Handle(FlyAttachment attachment)
        {
            var modifier = new FlyModifier(attachment.Id, attachment.Duration, _player);

            _modifierManager.AddModifier(modifier);
        }

        Type IAttachmentHandler.AttachmentType => typeof(FlyAttachment);

        void IAttachmentHandler.Handle(IAttachment attachment)
        {
            Handle((FlyAttachment)attachment);
        }
    }
}
