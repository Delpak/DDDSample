using System;
using System.Collections.Generic;
using Autofac;

namespace SAMA.Framework.Common.Helpers.Domain
{
    /// <summary>
    ///     http://www.udidahan.com/2009/06/14/domain-events-salvation/
    /// </summary>
    public static class DomainEvents
    {
        [ThreadStatic] //so that each thread has its own callbacks
        private static List<Delegate> actions;

        private static IContainer Container;

        public static void Init(IContainer container)
        {
            Container = container;
        }

        //Registers a callback for the given domain event, used for testing only
        public static void Register<T>(Action<T> callback) where T : DomainEvent
        {
            if (actions == null)
                actions = new List<Delegate>();

            actions.Add(callback);
        }

        //Clears callbacks passed to Register on the current thread
        public static void ClearCallbacks()
        {
            actions = null;
        }

        //Raises the given domain event
        public static void Raise<T>(T args) where T : DomainEvent
        {
            if (Container != null)
                foreach (var handler in Container.Resolve<IEnumerable<IHandles<T>>>())
                    handler.Handle(args);

            if (actions != null)
                foreach (var action in actions)
                    if (action is Action<T>)
                        ((Action<T>) action)(args);
        }
    }
}