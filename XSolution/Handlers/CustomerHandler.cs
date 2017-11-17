using System;
using NServiceBus;
using SAMA.XSolution.Domain.Infrastructure.Interfaces;
using SAMA.XSolution.Domain.Models;
using SAMA.XSolution.Domain.Specifications;
using SAMA.XSolution.Messages.Commands;
using SAMA.XSolution.Messages.Events;

namespace SAMA.XSolution.Handlers
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
