
using System;

namespace SAMA.FrameWork.Common.Domain.Model.LongRunningProcess
{
    public class ProcessId : Identity<Guid>
    {
        public static ProcessId ExistingProcessId(Guid id)
        {
            return new ProcessId(id);
        }

        public static ProcessId NewProcessId()
        {
            return new ProcessId(Guid.NewGuid());
        }

        public ProcessId(Guid id)
            : base(id)
        {
        }

        public ProcessId()
            : base()
        {
        }
    }
}
