using Client.Core.Modifiers;
using JetBrains.Annotations;

namespace Client.Core.Attachments
{
    [UsedImplicitly]
    public sealed class VelocityAttachmentHandler : IAttachmentHandler<VelocityAttachment>
    {
        private readonly IModifierManager _modifierManager;
        private readonly IPlayer _player;

        public VelocityAttachmentHandler(IModifierManager modifierManager, IPlayer player)
        {
            _modifierManager = modifierManager;
            _player = player;
        }

        void IAttachmentHandler<VelocityAttachment>.Handle(VelocityAttachment attachment)
        {
            var modifier = new VellocityModifier(attachment.Id, attachment.Duration, attachment.Ratio, _player);

            _modifierManager.AddModifier(modifier);
        }
    }
}
