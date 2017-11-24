using System.Threading.Tasks;

namespace SAMA.Framework.Common.WeapsyEvents
{
    public interface IEventHandlerAsync<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event);
    }
}
