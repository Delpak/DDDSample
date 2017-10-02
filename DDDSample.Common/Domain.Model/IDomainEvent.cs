﻿using System;

namespace DDDSample.Common.Domain.Model
{
    public interface IDomainEvent
    {
        int EventVersion { get; set;  }
        DateTime OccurredOn { get; set; }
    }
}
