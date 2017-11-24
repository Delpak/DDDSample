using System.Collections.Generic;
using SAMA.Framework.Common.WeapsyEvents;

namespace SAMA.Framework.Common.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        IEnumerable<IEvent> Handle(TCommand command);
    }
}