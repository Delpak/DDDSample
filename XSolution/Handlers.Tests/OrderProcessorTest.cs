﻿using System;
using BoundedContext.Domain.Model.Infrastructure.Interfaces;
using BoundedContext.Domain.Model.Models;
using BoundedContext.Domain.Model.Specifications;
using Moq;
using NServiceBus.Testing;
using NUnit.Framework;
using SAMA.XSolution.Handlers;
using SAMA.XSolution.Messages.Commands;
using SAMA.XSolution.Messages.Events;

namespace Handlers.Tests
{
    [TestFixture]
    public class OrderProcessorTest : NSBBaseTest
    {
        [Test]
        public void CreateOrder_NewCustomer()
        {
            var orderId = Guid.NewGuid();
            var customerId = Guid.NewGuid();

            var repository = new Mock<IRepository>();
            repository.Setup(x => x.Add(It.IsAny<Order>()))
                      .Callback<Order>(order =>
                                       {
                                           Assert.AreEqual(orderId, order.OrderId);
                                       });

            Test.Saga<OrderProcessor>()
                .WithExternalDependencies(processor => processor.Repository = repository.Object)
                .WhenHandling<CreateOrderCommand>(c =>
                                           {
                                               c.CustomerId = customerId;
                                               c.Email = "john.smith@domain.com";
                                               c.FirstName = "John";
                                               c.LastName = "Smith";
                                               c.OrderId = orderId;
                                               c.Address1 = "132 George St";
                                               c.Suburb = "Sydney";
                                               c.Postcode = "2001";
                                               c.State = "NSW";
                                               c.Country = "Australia";
                                           })
                .WhenHandling<ICustomerCreated>(e =>
                                                {
                                                    e.CustomerId = customerId;
                                                    e.Email = "johnsmith@domain.com";

                                                })
                .ExpectSend<CreateCustomerCommand>(customer => customer != null)
                .ExpectPublish<IOrderCreated>()
                .AssertSagaCompletionIs(true)
                ;
        }

        [Test]
        public void CreateOrder_ExistingCustomer()
        {
            var orderId = Guid.NewGuid();
            var customerId = new CustomerId(Guid.NewGuid().ToString());

            var repository = new Mock<IRepository>();
            repository.Setup(x => x.Load(It.IsAny<Func<Customer, bool>>())).Returns(new Customer(customerId, "John", "Smith", "john.smith@domain.com", new Mock<IDuplicateCustomerEmail>().Object));
            repository.Setup(x => x.Add(It.IsAny<Order>()))
                      .Callback<Order>(order =>
                      {
                          Assert.AreEqual(orderId, order.OrderId);
                      });

            Test.Saga<OrderProcessor>()
                .WithExternalDependencies(processor => processor.Repository = repository.Object)
                .WhenHandling<CreateOrderCommand>(c =>
                {
                    c.CustomerId = Guid.Parse(customerId.ToString());
                    c.Email = "john.smith@domain.com";
                    c.FirstName = "John";
                    c.LastName = "Smith";
                    c.OrderId = orderId;
                    c.Address1 = "132 George St";
                    c.Suburb = "Sydney";
                    c.Postcode = "2001";
                    c.State = "NSW";
                    c.Country = "Australia";
                })
                .WhenHandling<ICustomerCreated>()
                .ExpectNotSend<CreateCustomerCommand>(customer => customer == null)
                .ExpectPublish<IOrderCreated>()
                .AssertSagaCompletionIs(true)
                ;


        }
    }
}
