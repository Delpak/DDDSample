using System;
using System.Collections;
using System.Collections.Generic;
using SAMA.Framework.Common.Interfaces;

namespace SAMA.Framework.Common
{
    public abstract class AggregateBase : IContainsEventAggregate
    {
        readonly ICollection<object> _uncommittedEvents = new LinkedList<object>();
        IRouteEvents _registeredRoutes;

        public int Version { get; protected set; }

        protected AggregateBase(): this(null){}
        protected AggregateBase(IRouteEvents handler)
        {
            if (handler == null) return;

            this.RegisteredRoutes = handler;
            this.RegisteredRoutes.Register(this);
        }
        protected IRouteEvents RegisteredRoutes
        {
            get
            {
                return _registeredRoutes ?? (_registeredRoutes = new ConventionEventRouter(true, this));
            }
            set
            {
                if (value == null)
                    throw new InvalidOperationException("AggregateBase must have an event router to function");

                _registeredRoutes = value;
            }
        }
        protected void Register<T>(Action<T> route)
        {
            this.RegisteredRoutes.Register(route);
        }
        protected void RaiseEvent(object @event)
        {
            ((IContainsEventAggregate)this).ApplyEvent(@event);
            _uncommittedEvents.Add(@event);
        }
        void IContainsEventAggregate.ApplyEvent(object @event)
        {
            RegisteredRoutes.Dispatch(@event);
            Version++;
        }
        ICollection IContainsEventAggregate.GetUncommittedEvents()
        {
            return (ICollection)_uncommittedEvents;
        }
        void IContainsEventAggregate.ClearUncommittedEvents()
        {
            _uncommittedEvents.Clear();
        }
    }
}