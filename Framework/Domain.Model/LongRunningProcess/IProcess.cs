using System;

namespace SAMA.FrameWork.Common.Domain.Model.LongRunningProcess
{
    public interface IProcess
    {
        long AllowableDuration();

        bool CanTimeout();

        long CurrentDuration();

        string Description();

        bool DidProcessingComplete();

        void InformTimeout(DateTime timedOutDate);

        bool IsCompleted();

        bool IsTimedOut();

        bool NotCompleted();

        ProcessCompletionType ProcessCompletionType();

        ProcessId ProcessId();

        DateTime StartTime();

        TimeConstrainedProcessTracker TimeConstrainedProcessTracker();

        DateTime TimedOutDate();

        long TotalAllowableDuration();

        int TotalRetriesPermitted();
    }

    public enum ProcessCompletionType
    {
        NotCompleted,
        CompletedNormally,
        TimedOut
    }
}
