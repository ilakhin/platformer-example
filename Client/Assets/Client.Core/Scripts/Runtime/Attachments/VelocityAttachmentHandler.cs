using System;
using Client.Core.Modifiers;
using JetBrains.Annotations;

namespace Client.Core.Attachments
{
    // Обработчик прикрепления - модификатор скорости (ускорение / замедление).
    [UsedImplicitly]
    public sealed class VelocityAttachmentHandler : IAttachmentHandler
    {
        private readonly IModifierManager _modifierManager;
        private readonly IPlayer _player;

        public VelocityAttachmentHandler(IModifierManager modifierManager, IPlayer player)
        {
            _modifierManager = modifierManager;
            _player = player;
        }

        private void Handle(VelocityAttachment attachment)
        {
            var modifier = new VellocityModifier(attachment.Id, attachment.Duration, attachment.Ratio, _player);

            _modifierManager.AddModifier(modifier);
        }

        Type IAttachmentHandler.AttachmentType => typeof(VelocityAttachment);

        void IAttachmentHandler.Handle(IAttachment attachment)
        {
            Handle((VelocityAttachment)attachment);
        }
    }
}
