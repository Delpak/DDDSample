using System;

namespace SAMA.Framework.Common.WeapsyEvents
{
    public interface IEvent
    {
        DateTime TimeStamp { get; set; }
        Guid UserId { get; set; }
    }
}
