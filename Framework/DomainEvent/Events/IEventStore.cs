using SAMA.Framework.Common.Domain.Model;

namespace SAMA.Framework.Common.Events
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
