using System;

namespace SAMA.Framework.Common.Domain.Model
{
    public interface IWeapsyEvent
    {
        DateTime TimeStamp { get; set; }
        Guid UserId { get; set; }
    }
}