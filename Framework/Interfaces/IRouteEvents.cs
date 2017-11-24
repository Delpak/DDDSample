using System;

namespace SAMA.Framework.Common.Interfaces
{
    public interface IRouteEvents
    {
        void Register<T>(Action<T> handler);
        void Register(IContainsEventAggregate aggregate);

        void Dispatch(object eventMessage);
    }
}
