using System;
using System.Collections.Generic;
using SAMA.Framework.Common.Domain.Model;

namespace SAMA.Framework.Common.Helpers.Domain
{
    public interface IWeapsyAggregateRoot : IAggregateRoot<Guid>
    {
        ICollection<IDomainEvent> Events { get; }
    }
}