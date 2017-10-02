using System;
using System.Threading.Tasks;
using Domain.Infrastructure.Interfaces;
using Domain.Models;
using Domain.Specifications;
using MassTransit;
using Messages.Commands;
using Messages.Events;

namespace Host.Masstransit.Consumers
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
            var customer = new Customer(context.Message.CustomerId, context.Message.FirstName, context.Message.LastName, context.Message.Email, _duplicateCustomerEmail);

            _repository.Add(customer);

            await _bus.Publish<ICustomerCreated>(new
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email

            });

            Console.WriteLine($"CreateCustomerConsumer: Message recived {context.Message.FirstName}");

        }
    }
}
