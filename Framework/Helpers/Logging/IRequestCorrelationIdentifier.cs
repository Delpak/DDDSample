namespace SAMA.Framework.Common.Helpers.Logging
{
    public interface IRequestCorrelationIdentifier
    {
        string CorrelationID { get; }
    }
}