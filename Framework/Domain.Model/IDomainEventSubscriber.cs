using System;

namespace SAMA.FrameWork.Common.Domain.Model
{
    public interface IDomainEventSubscriber<T> where T : IDomainEvent
    {
        void HandleEvent(T domainEvent);
        Type SubscribedToEventType();
    }
}
