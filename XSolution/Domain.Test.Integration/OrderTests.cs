﻿using System;
using Moq;
using NUnit.Framework;
using SAMA.XSolution.Domain.Exceptions;
using SAMA.XSolution.Domain.Models;
using SAMA.XSolution.Domain.Specifications;
using SAMA.XSolution.Repository.EF.Query;

namespace SAMA.XSolution.Domain.Integration.Test
{
    [TestFixture]
    public class OrderTests : SqlCeBaseTest
    {
        Mock<IDuplicateCustomerEmail> _duplicateCustomerEmail;

        [SetUp]
        public void Setup()
        {
            _duplicateCustomerEmail = new Mock<IDuplicateCustomerEmail>();
        }

        [Test]
        public void CreateOrder()
        {
            var customerId = new CustomerId(Guid.NewGuid().ToString());
            var customerFullName = "Test Customer";
            var domain = DefaultOrder(customerId, customerFullName);
            domain.AddOrderLine("Test Product", 1, 10.95m);

            var customer = CustomerTests.DefaulCustomer(_duplicateCustomerEmail.Object);

            Repository(repository =>
                       {
                           repository.Add(customer);
                           repository.Add(domain);
                       });

            Repository(repository =>
                       {
                           var order = repository.Load<Order>(x => x.OrderId == domain.OrderId,
                               i => i.OrderLines);

                           Assert.NotNull(order);
                           Assert.NotNull(order.OrderLines);
                           Assert.AreEqual(customerId, order.CustomerId);
                           Assert.AreEqual(customerFullName, order.CustomerFullName);
                           Assert.AreEqual(1, order.OrderLines.Count);
                       });
        }

        [Test, ExpectedException(typeof(CustomerLimitReachedException))]
        public void CreateOrder_UnableToProcessOverlimitCustomer()
        {
            var customerCreditLimitReached = new Mock<ICustomerCreditLimitReached>();
            customerCreditLimitReached.Setup(x => x.IsSatisfiedBy(It.IsAny<Order>())).Returns(true);

            var domain = DefaultOrder();
            domain.ProcessingOrder(customerCreditLimitReached.Object);
        }

        [Test]
        public void CreateOrder_PaidInFull()
        {



            //var customerCreditLimitReached = new Mock<ICustomerCreditLimitReached>();
            //customerCreditLimitReached.Setup(x => x.IsSatisfiedBy(It.IsAny<Order>())).Returns(false);
            var customer = CustomerTests.DefaulCustomer(new Mock<IDuplicateCustomerEmail>().Object);
            Repository(s => s.Add(customer));

            Repository(r => r.Add(DefaultOrder(customerId: customer.CustomerId)));

            var domain = DefaultOrder(customerId: customer.CustomerId);
            var orderValue = 11.95m;

            Repository(repository =>
            {
                var customerCreditLimitReached = new CustomerCreditLimitReached(repository);

                domain.AddOrderLine("Test Product", 1, orderValue);
                domain.ProcessingOrder(customerCreditLimitReached);
                domain.AddPayment(DateTime.Now, orderValue, true);

                repository.Add(domain);
            });

            Repository(repository =>
            {

                var order = repository.Load<Order>(x => x.OrderId == domain.OrderId,
                                                   i => i.OrderLines,
                                                   i => i.OrderPayments);

                Assert.AreEqual(orderValue, order.TotalValue);
                Assert.AreEqual(orderValue, order.TotalPaid);
            });
        }

        [Test]
        public void CreateOrder_FindByCustomerId()
        {
            var customerId = new CustomerId(Guid.NewGuid().ToString());
            var customerFullName = "Test Customer";
            var domain = DefaultOrder(customerId, customerFullName);
            domain.AddOrderLine("Test Product", 1, 10.95m);

            Repository(repository => repository.Add(domain));

            Repository(repository =>
            {
                var q = new CustomerOrders { CustomerId = customerId };
                var orders = repository.Search(q);
                Assert.AreEqual(1, orders.TotalFound);
            });
        }


        public static Order DefaultOrder(CustomerId customerId = null, string fullName = null, OrderId orderId = null, string address1 = "", string address2 = "", string suburb = "", string postcode = "", string state = "", string country = "")
        {
            //if (!customerId.HasValue) customerId = Guid.NewGuid();
            if (string.IsNullOrWhiteSpace(fullName)) fullName = "Test Customer";
            if (orderId == null) orderId = new OrderId(Guid.NewGuid());

            return new Order(orderId, customerId, fullName, address1, address2, suburb, state, postcode, country);
        }
    }
}
