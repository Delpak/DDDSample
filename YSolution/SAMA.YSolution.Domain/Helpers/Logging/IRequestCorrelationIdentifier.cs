namespace SAMA.YSolution.Domain.Helpers.Logging
{
    public interface IRequestCorrelationIdentifier
    {
        string CorrelationID { get; }
    }
}