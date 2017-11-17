namespace SAMA.YSolution.Domain.Helpers.Domain
{
    public interface IHandles<T> where T : DomainEvent
    {
        void Handle(T args);
    }
}