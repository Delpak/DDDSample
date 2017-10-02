using System.Collections;

namespace Domain.Infrastructure
{
    public interface IAggregate
    {
        void ApplyEvent(object e);
        ICollection GetUncommittedEvents();
        void ClearUncommittedEvents();
    }
}
