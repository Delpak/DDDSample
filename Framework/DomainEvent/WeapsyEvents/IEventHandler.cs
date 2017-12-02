namespace SAMA.Framework.Common.WeapsyEvents
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        void Handle(TEvent @event);
    }
}
