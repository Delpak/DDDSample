using DDDSample.Common.Domain.Model;

namespace DDDSample.Common.Events
{
    public interface IEventStore
    {
        long CountStoredEvents();

        StoredEvent[] GetAllStoredEventsSince(long storedEventId);

        StoredEvent[] GetAllStoredEventsBetween(long lowStoredEventId, long highStoredEventId);

        StoredEvent Append(IDomainEvent domainEvent);

        void Close();
    }
}
