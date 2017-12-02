using System.Threading.Tasks;
using SAMA.Framework.Common.Domain.Model;
using SAMA.Framework.Common.Helpers.Domain;

namespace SAMA.Framework.Common.Events
{
    public interface IWeapsyEventStore
    {
        void SaveEvent<TAggregate>(IWeapsyDomainEvent @event) where TAggregate : IWeapsyAggregateRoot;
        Task SaveEventAsync<TAggregate>(IWeapsyDomainEvent @event) where TAggregate : IWeapsyAggregateRoot;
    }
}
