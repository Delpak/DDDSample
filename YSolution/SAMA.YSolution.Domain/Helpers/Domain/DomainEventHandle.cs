using SAMA.YSolution.Domain.Helpers.Logging;
using SAMA.YSolution.Domain.Helpers.Repository;

namespace SAMA.YSolution.Domain.Helpers.Domain
{
    public class DomainEventHandle<TDomainEvent> : IHandles<TDomainEvent>
        where TDomainEvent : DomainEvent
    {
        private readonly IDomainEventRepository domainEventRepository;
        private readonly IRequestCorrelationIdentifier requestCorrelationIdentifier;

        public DomainEventHandle(IDomainEventRepository domainEventRepository,
            IRequestCorrelationIdentifier requestCorrelationIdentifier)
        {
            this.domainEventRepository = domainEventRepository;
            this.requestCorrelationIdentifier = requestCorrelationIdentifier;
        }

        public void Handle(TDomainEvent @event)
        {
            @event.Flatten();
            @event.CorrelationID = requestCorrelationIdentifier.CorrelationID;
            domainEventRepository.Add(@event);
        }
    }
}