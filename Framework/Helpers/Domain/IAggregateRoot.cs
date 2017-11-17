using System;

namespace SAMA.Framework.Common.Helpers.Domain
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}