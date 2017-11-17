using System.Collections.Generic;
using SAMA.YSolution.Domain.Helpers.Domain;

namespace SAMA.YSolution.Domain.Helpers.Repository
{
    public interface IDomainEventRepository
    {
        void Add<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : DomainEvent;
        IEnumerable<DomainEventRecord> FindAll();
    }
}