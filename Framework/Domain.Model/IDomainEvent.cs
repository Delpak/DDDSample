using System;

namespace SAMA.FrameWork.Common.Domain.Model
{
    public interface IDomainEvent
    {
        int EventVersion { get; set;  }
        DateTime OccurredOn { get; set; }
    }
}
