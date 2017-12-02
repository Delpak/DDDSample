using System;

namespace SAMA.Framework.Common.Domain.Model
{
    public interface IDomainEvent
    {
        int Version { get; set;  }
        DateTime OccurredOn { get; set; }
        Guid AggregateRootId { get; set; }
        Guid UserId { get; set; }
    }
}
