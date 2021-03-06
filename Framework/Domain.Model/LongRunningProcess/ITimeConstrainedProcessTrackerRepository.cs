﻿using System.Collections.Generic;

namespace SAMA.Framework.Common.Domain.Model.LongRunningProcess
{
    public interface ITimeConstrainedProcessTrackerRepository
    {
        void Add(TimeConstrainedProcessTracker processTracker);

        ICollection<TimeConstrainedProcessTracker> GetAllTimedOut();

        ICollection<TimeConstrainedProcessTracker> GetAllTimedOutOf(string tenantId);

        ICollection<TimeConstrainedProcessTracker> GetAll(string tenantId);

        void Save(TimeConstrainedProcessTracker processTracker);

        TimeConstrainedProcessTracker Get(string tenantId, ProcessId processId); 
    }
}
