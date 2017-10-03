namespace DDDSample.Common.Domain.Model
{
    public interface IIdentity<T>
    {
        T Id { get; }
    }
}
