using System;
using BoundedContext.Domain.Model.Infrastructure.Interfaces;
using BoundedContext.Domain.Model.Models;
using BoundedContext.Domain.Model.Specifications;
using Messages.Commands;
using Messages.Events;
using NServiceBus;

namespace Handlers
{
    public class CustomerHandler:IHandleMessages<CreateCustomerCommand>
    {
        readonly IRepository _repository;
        readonly IBus _bus;
        readonly IDuplicateCustomerEmail _duplicateCustomerEmail;
        
        

        public CustomerHandler(IRepository repository, IBus bus,IDuplicateCustomerEmail duplicateCustomerEmail)
        {
            _repository = repository;
            _bus = bus;
            _duplicateCustomerEmail = duplicateCustomerEmail;
            
        }

        public void Handle(CreateCustomerCommand message)
        {
            var customer = new Customer(new CustomerId( message.CustomerId.ToString()), message.FirstName, message.LastName, message.Email, _duplicateCustomerEmail);

            _repository.Add(customer);

            _bus.Publish<ICustomerCreated>(e =>
                                           {
                                               e.CustomerId = Guid.Parse( customer.CustomerId.ToString());
                                               e.FirstName = customer.FirstName;
                                               e.LastName = customer.LastName;
                                               e.Email = customer.Email;

                                           });
        }
    }
}
