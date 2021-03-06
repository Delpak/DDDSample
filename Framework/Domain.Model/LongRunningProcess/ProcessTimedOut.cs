﻿using System;

namespace SAMA.Framework.Common.Domain.Model.LongRunningProcess
{
    public class ProcessTimedOut : IDomainEvent
    {
        public ProcessTimedOut(
                string tenantId,
                ProcessId processId,
                int totalRetriesPermitted,
                int retryCount)
        {
            this.Version = 1;
            this.OccurredOn = DateTime.Now;
            this.ProcessId = processId;
            this.RetryCount = retryCount;
            this.TenantId = tenantId;
            this.TotalRetriesPermitted = totalRetriesPermitted;
        }

        public int Version { get; set; }
        public DateTime OccurredOn { get; set; }
        public Guid AggregateRootId { get; set; }
        public Guid UserId { get; set; }
        public ProcessId ProcessId { get; private set; }
        public int RetryCount { get; private set; }
        public string TenantId { get; private set; }
        public int TotalRetriesPermitted { get; private set; }
    }
}
