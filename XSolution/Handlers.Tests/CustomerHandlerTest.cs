using System;
using BoundedContext.Domain.Model.Exceptions;
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
    public class CustomerHandlerTest:NSBBaseTest
    {
        [Test]
        public void CreateCustomer_Basic()
        {
            var cmd = new CreateCustomerCommand
                      {
                          CustomerId = Guid.NewGuid(),
                          FirstName = "John",
                          LastName = "Smith",
                          Email = "john.smith@domain.com"
                      };

            var repository = new Mock<IRepository>();
            var dup = new Mock<IDuplicateCustomerEmail>();
            dup.Setup(x => x.IsSatisfiedBy(It.IsAny<Customer>())).Returns(false);

            Test.Handler(bus => new CustomerHandler(repository.Object, bus, dup.Object))
                .ExpectPublish<ICustomerCreated>(e => e.CustomerId == cmd.CustomerId && e.Email == cmd.Email)
                .OnMessage(cmd);
        }

        [Test]
        [ExpectedException(typeof (DuplicateEmailException))]
        public void CreateCustomer_DuplicateEmail()
        {
            var cmd = new CreateCustomerCommand
            {
                CustomerId = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Smith",
                Email = "john.smith@domain.com"
            };

            var repository = new Mock<IRepository>();
            var dup = new Mock<IDuplicateCustomerEmail>();
            dup.Setup(x => x.IsSatisfiedBy(It.IsAny<Customer>())).Returns(true);

            Test.Handler(bus => new CustomerHandler(repository.Object, bus, dup.Object))
                .ExpectNotPublish<ICustomerCreated>(e => e.CustomerId == cmd.CustomerId && e.Email == cmd.Email)
                .OnMessage(cmd);
        }
    }
}
