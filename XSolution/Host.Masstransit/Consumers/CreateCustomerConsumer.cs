using System;
using System.Threading.Tasks;
using MassTransit;
using SAMA.Framework.Common.Interfaces;
using SAMA.XSolution.Domain.Models;
using SAMA.XSolution.Domain.Specifications;
using SAMA.XSolution.Messages.Commands;
using SAMA.XSolution.Messages.Events;

namespace SAMA.XSolution.Endpoint.Consumers
{
    public class CreateCustomerConsumer : IConsumer<CreateCustomerCommand>
    {
        readonly IRepository _repository;
        readonly IBus _bus;
        readonly IDuplicateCustomerEmail _duplicateCustomerEmail;

        public CreateCustomerConsumer(IRepository repository, IBus bus, IDuplicateCustomerEmail duplicateCustomerEmail)
        {
            _repository = repository;
            _bus = bus;
            _duplicateCustomerEmail = duplicateCustomerEmail;
        }

        public async Task Consume(ConsumeContext<CreateCustomerCommand> context)
        {
            var customer = new Customer(new CustomerId(context.Message.CustomerId.ToString()), context.Message.FirstName, context.Message.LastName, context.Message.Email, _duplicateCustomerEmail);

            _repository.Add(customer);

            await _bus.Publish<ICustomerCreated>(new
            {
                CustomerId = Guid.Parse(customer.CustomerId.ToString()),
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email

            });

            Console.WriteLine($"CreateCustomerConsumer: Message recived {context.Message.FirstName}");

        }
    }
}
