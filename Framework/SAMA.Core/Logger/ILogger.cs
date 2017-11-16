namespace SAMA.Core.Logger
{
    public interface ILogger
    {
        void Log();
        void Debug();
        void Error();
        void Fatal();
        void Warn();

    }

}
