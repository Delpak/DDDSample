using System.Threading.Tasks;
using SAMA.Framework.Common.Helpers.Domain;

namespace SAMA.Framework.Common.Commands
{
    public interface ICommandSender
    {
        void Send<TCommand>(TCommand command, bool publishEvents = true)
            where TCommand : ICommand;

        void Send<TCommand, TAggregate>(TCommand command, bool publishEvents = true) 
            where TCommand : ICommand 
            where TAggregate : IWeapsyAggregateRoot;

        Task SendAsync<TCommand>(TCommand command, bool publishEvents = true)
            where TCommand : ICommand;

        Task SendAsync<TCommand, TAggregate>(TCommand command, bool publishEvents = true)
            where TCommand : ICommand
            where TAggregate : IWeapsyAggregateRoot;
    }
}
