using System.Collections.Generic;
using Client.Core.Attachments;

namespace Client.Core
{
    public interface IItem : IEntity
    {
        IEnumerable<IAttachment> Attachments
        {
            get;
        }
    }
}
