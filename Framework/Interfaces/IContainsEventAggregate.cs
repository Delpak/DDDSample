using System.Collections;

namespace SAMA.Framework.Common.Interfaces
{
    public interface IContainsEventAggregate
    {
        void ApplyEvent(object e);
        ICollection GetUncommittedEvents();
        void ClearUncommittedEvents();
    }
}
