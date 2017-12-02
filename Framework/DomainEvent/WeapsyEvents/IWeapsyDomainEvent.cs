using System;

namespace SAMA.Framework.Common.Domain.Model
{
    public interface IWeapsyDomainEvent : IWeapsyEvent
    {
        Guid AggregateRootId { get; set; }
        int Version { get; set; }
    }
}