using System.Collections.Generic;

namespace SAMA.Core.DependencyResolver
{
    public interface IResolver
    {
        T Resolve<T>();
        IEnumerable<T> ResolveAll<T>();
    }
}
