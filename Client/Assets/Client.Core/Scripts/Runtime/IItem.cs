using System.Collections.Generic;
using Client.Core.Attachments;

namespace Client.Core
{
    public interface IItem
    {
        IEnumerable<IAttachment> Attachments
        {
            get;
        }

        void SetActive(bool active);
    }
}
