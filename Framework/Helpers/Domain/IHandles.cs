namespace SAMA.Framework.Common.Helpers.Domain
{
    public interface IHandles<T> where T : DomainEvent
    {
        void Handle(T args);
    }
}