using System.Collections.Generic;
using Client.Core.Attachments;

namespace Client.Core
{
    // Предмет (монеты, бонусы и тд).
    public interface IItem : IEntity
    {
        IEnumerable<IAttachment> Attachments
        {
            get;
        }
    }
}
