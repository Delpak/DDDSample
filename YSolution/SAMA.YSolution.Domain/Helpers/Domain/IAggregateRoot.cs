using System;

namespace SAMA.YSolution.Domain.Helpers.Domain
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}