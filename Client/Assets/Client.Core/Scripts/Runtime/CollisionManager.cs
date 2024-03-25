using Client.Core.Attachments;
using JetBrains.Annotations;

namespace Client.Core
{
    [UsedImplicitly]
    public sealed class CollisionManager : ICollisionManager
    {
        private readonly RegionController _regionController;
        private readonly IAttachmentManager _attachmentManager;

        public CollisionManager(RegionController regionController, IAttachmentManager attachmentManager)
        {
            _regionController = regionController;
            _attachmentManager = attachmentManager;
        }

        void ICollisionManager.OnTriggerEnter(IPlayer player, ITrigger trigger)
        {
            switch (trigger)
            {
                case UpdateTrigger:
                {
                    _regionController.Recreate();

                    break;
                }
                case IItem item:
                {
                    item.SetActive(false);

                    foreach (var attachment in item.Attachments)
                    {
                        attachment.Handle(_attachmentManager);
                    }

                    break;
                }
            }
        }
    }
}
