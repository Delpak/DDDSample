using System;
using BoundedContext.Domain.Model.Infrastructure.Interfaces;
using BoundedContext.Domain.Model.Models;
using Messages.Commands;
using Messages.Events;
using Ninject;
using NServiceBus;
using NServiceBus.Saga;
using Order = BoundedContext.Domain.Model.Models.Order;

namespace Handlers
{
    public class OrderProcessor : Saga<OrderProcessorState>, IAmStartedByMessages<CreateOrderCommand>, IHandleMessages<ICustomerCreated>
    {
        [Inject]
        public IRepository Repository { private get; set; }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<OrderProcessorState> mapper)
        {
            mapper.ConfigureMapping<CreateOrderCommand>(m => m.OrderId).ToSaga(s => s.OrderId);
            mapper.ConfigureMapping<ICustomerCreated>(m => m.CustomerId).ToSaga(s => s.CustomerId);
        }

        public void Handle(CreateOrderCommand message)
        {
            Data.CustomerId = new CustomerId(message.CustomerId.ToString());
            Data.Email = message.Email;
            Data.FirstName = message.FirstName;
            Data.LastName = message.LastName;
            Data.OrderId = message.OrderId;


            // ensure the customer exists, if not, create it
            var customer = Repository.Load<Customer>(x => x.CustomerId == new CustomerId(message.CustomerId.ToString()));
            if (customer == null)
            {
                Bus.Send(new CreateCustomerCommand
                {
                    CustomerId = Guid.Parse(Data.CustomerId.ToString()),
                    Email = Data.Email,
                    FirstName = Data.FirstName,
                    LastName = Data.LastName

                });
                return;
            }

            CreateOrder();
            EndOrderProcess();
        }
        public void Handle(ICustomerCreated message)
        {
            CreateOrder();
            EndOrderProcess();
        }

        void CreateOrder()
        {
            var order = new Order(new OrderId(Data.OrderId), Data.CustomerId, string.Format("{0} {1}", Data.FirstName, Data.LastName),
                                                Data.Address1, Data.Address2, Data.Suburb, Data.State, Data.Postcode, Data.Country);
            Repository.Add(order);
        }

        void EndOrderProcess()
        {
            Bus.Publish<IOrderCreated>(e =>
                                       {
                                           e.OrderId = Data.OrderId;
                                       });

            MarkAsComplete();
        }
    }

    public class OrderProcessorState : IContainSagaData
    {
        public virtual Guid Id { get; set; }
        public virtual string Originator { get; set; }
        public virtual string OriginalMessageId { get; set; }

        public virtual CustomerId CustomerId { get; set; }
        public virtual string Email { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public virtual Guid OrderId { get; set; }
        public virtual string Address1 { get; set; }
        public virtual string Address2 { get; set; }
        public virtual string Suburb { get; set; }
        public virtual string State { get; set; }
        public virtual string Postcode { get; set; }
        public virtual string Country { get; set; }
    }
}
