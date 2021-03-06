﻿using System;
using System.Threading.Tasks;
using SAMA.Core.DependencyResolver;
using SAMA.Framework.Common.Domain.Model;
using SAMA.Framework.Common.Events;
using SAMA.Framework.Common.Helpers.Domain;
using SAMA.Framework.Common.WeapsyEvents;

namespace SAMA.Framework.Common.Commands
{
    public class WeapsyCommandSender : ICommandSender
    {
        private readonly IResolver _resolver;
        private readonly IEventPublisher _eventPublisher;
        private readonly IWeapsyEventStore _eventStore;

        public WeapsyCommandSender(IResolver resolver,
            IEventPublisher eventPublisher,
            IWeapsyEventStore eventStore)
        {
            _resolver = resolver;
            _eventPublisher = eventPublisher;
            _eventStore = eventStore;
        }

        public void Send<TCommand>(TCommand command, bool publishEvents = true) where TCommand : ICommand
        {
            var commandHandler = GetHandler<ICommandHandler<TCommand>, TCommand>(command);

            var events = commandHandler.Handle(command);

            if (!publishEvents)
                return;

            foreach (var @event in events)
            {
                var concreteEvent = EventFactory.CreateConcreteEvent(@event);
                _eventPublisher.Publish(concreteEvent);
            }
        }

        public void Send<TCommand, TAggregate>(TCommand command, bool publishEvents = true)
            where TCommand : ICommand
            where TAggregate : IWeapsyAggregateRoot
        {
            var commandHandler = GetHandler<ICommandHandler<TCommand>, TCommand>(command);

            var events = commandHandler.Handle(command);

            foreach (var @event in events)
            {
                var concreteEvent = EventFactory.CreateConcreteEvent(@event);

                _eventStore.SaveEvent<TAggregate>((IWeapsyDomainEvent)concreteEvent);
                
                if (!publishEvents)
                    continue;

                _eventPublisher.Publish(concreteEvent);
            }
        }

        public async Task SendAsync<TCommand>(TCommand command, bool publishEvents = true) where TCommand : ICommand
        {
            var commandHandler = GetHandler<ICommandHandlerAsync<TCommand>, TCommand>(command);

            var events = await commandHandler.HandleAsync(command);

            if (!publishEvents)
                return;

            foreach (var @event in events)
            {
                var concreteEvent = EventFactory.CreateConcreteEvent(@event);
                await _eventPublisher.PublishAsync(concreteEvent);
            }
        }

        public async Task SendAsync<TCommand, TAggregate>(TCommand command, bool publishEvents = true) 
            where TCommand : ICommand 
            where TAggregate : IWeapsyAggregateRoot
        {
            var commandHandler = GetHandler<ICommandHandlerAsync<TCommand>, TCommand>(command);

            var events = await commandHandler.HandleAsync(command);

            foreach (var @event in events)
            {
                var concreteEvent = EventFactory.CreateConcreteEvent(@event);

                await _eventStore.SaveEventAsync<TAggregate>((IWeapsyDomainEvent)concreteEvent);

                if (!publishEvents)
                    continue;

                await _eventPublisher.PublishAsync(concreteEvent);
            }
        }

        private THandler GetHandler<THandler, TCommand>(TCommand command) where TCommand : ICommand 
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var commandHandler = _resolver.Resolve<THandler>();

            if (commandHandler == null)
                throw new Exception($"No handler found for command '{command.GetType().FullName}'");

            return commandHandler;
        }
    }
}
