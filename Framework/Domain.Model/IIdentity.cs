namespace SAMA.FrameWork.Common.Domain.Model
{
    public interface IIdentity<T>
    {
        T Id { get; }
    }
}
