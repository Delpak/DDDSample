using System;
using System.Threading.Tasks;
using MassTransit;
using SAMA.XSolution.Messages.Commands;

namespace SAMA.XSolution.Endpoint.Consumers
{
    public class CreateOrerConsumer : IConsumer<CreateOrderCommand>
    {
        //readonly IRepository _repository;
        //readonly IBus _bus;
        //readonly IDuplicateCustomerEmail _duplicateCustomerEmail;
        //protected CreateCustomerConsumer() { }
        //public CreateCustomerConsumer(IRepository repository, IBus bus, IDuplicateCustomerEmail duplicateCustomerEmail)
        //{
        //    _repository = repository;
        //    _bus = bus;
        //    _duplicateCustomerEmail = duplicateCustomerEmail;
        //}

        public async Task Consume(ConsumeContext<CreateOrderCommand> context)
        {
            //await Task.Delay(1000);
            Console.WriteLine($"CreateOrerConsumer: Message recived{context.Message.CustomerId}");
            //var customer = new Customer(context.Message.CustomerId, context.Message.FirstName, context.Message.LastName, context.Message.Email, _duplicateCustomerEmail);

            //_repository.Add(customer);

            //await _bus.Publish<ICustomerCreated>(new
            //{
            //    CustomerId = customer.CustomerId,
            //    FirstName = customer.FirstName,
            //    LastName = customer.LastName,
            //    Email = customer.Email

            //});
        }
    }
}