using System.Collections.Generic;
using System.Threading.Tasks;
using SAMA.Framework.Common.WeapsyEvents;

namespace SAMA.Framework.Common.Commands
{
    public interface ICommandHandlerAsync<in TCommand> where TCommand : ICommand
    {
        Task<IEnumerable<IEvent>> HandleAsync(TCommand command);
    }
}
