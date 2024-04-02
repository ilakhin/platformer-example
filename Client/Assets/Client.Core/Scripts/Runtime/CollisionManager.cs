using System;
using Client.Core.Attachments;
using JetBrains.Annotations;

namespace Client.Core
{
    // Используется для менеджмента коллизий (Player / Trigger).
    [UsedImplicitly]
    public sealed class CollisionManager : ICollisionManager
    {
        private readonly RegionController _regionController;
        private readonly IAttachmentManager _attachmentManager;
        private readonly ICoinManager _coinManager;

        public CollisionManager(RegionController regionController, IAttachmentManager attachmentManager, ICoinManager coinManager)
        {
            _regionController = regionController;
            _attachmentManager = attachmentManager;
            _coinManager = coinManager;
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
                case IEnemy enemy:
                {
                    enemy.SetActive(false);

                    var coins = _coinManager.Coins;

                    coins.Value = Math.Clamp(coins.Value - 20, 0, int.MaxValue);

                    break;
                }
                case IItem item:
                {
                    item.SetActive(false);

                    foreach (var attachment in item.Attachments)
                    {
                        _attachmentManager.Handle(attachment);
                    }

                    break;
                }
            }
        }
    }
}
