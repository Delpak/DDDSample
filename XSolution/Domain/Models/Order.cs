using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using BoundedContext.Domain.Model.Events.Orders;
using BoundedContext.Domain.Model.Exceptions;
using BoundedContext.Domain.Model.Infrastructure;
using BoundedContext.Domain.Model.Specifications;
using SAMA.FrameWork.Common.Domain.Model;

namespace BoundedContext.Domain.Model.Models
{
    [ComplexType]
    public class OrderId : Identity<Guid>
    {
        protected OrderId() { }
        public OrderId(Guid id) : base(id)
        {
        }
    }
    /// <summary>
    /// Order Domain implement CQRS by inheriting from AggregateBase
    /// </summary>
    public class Order : AggregateBase
    {
        public OrderState State { get; }

        #region Ctor
        public Order(OrderState orderState)
        {
            State = orderState;
        }
        public Order(OrderId orderId, CustomerId customerId, string customerFullName, string address1, string address2, string suburb, string state, string postcode, string country)
        {
            this.State = new OrderState()
            {
                Address1 = address1,
                Address2 = address2,
                Country = country,
                CustomerFullName = customerFullName,
                CutomerId = customerId.Id,
                OrderId = orderId.Id,
                Postcode = postcode,
                State = state,
                Suburb = suburb

            };

            RaiseEvent(new OrderCreated
            {
                OrderId = orderId,
                CustomerId = customerId,
                CustomerFullName = customerFullName,
                OrderStatus = OrderStatus.Draft.ToString(),
                ShippingAddress1 = address1,
                ShippingAddress2 = address2,
                ShippingSuburb = suburb,
                ShippingPostcode = postcode,
                ShippingState = state,
                ShippingCountry = country,
            });

        }
        #endregion

        public OrderId OrderId
        {
            get => new OrderId(State.OrderId);
            private set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
            }
        }
        public CustomerId CustomerId => new CustomerId(State.CutomerId);
        public string CustomerFullName { get; private set; }

        public ICollection<OrderLine> OrderLines { get; private set; }
        public ICollection<OrderPayment> OrderPayments { get; private set; }

        public decimal? TotalValue
        {
            get { return OrderLines == null ? (decimal?)null : OrderLines.Sum(x => x.QTY * x.Price); }
            private set { }
        }
        public decimal? TotalPaid
        {
            get { return OrderPayments == null ? (decimal?)null : OrderPayments.Where(x => x.IsSuccessful).Sum(x => x.PaymentAmount); }
            private set { }
        }

        public Address ShippingAddress => State.ShippingAddress;
        public OrderStatus OrderStatus => State.OrderStatus;
        public void ChangeCustomerName(string customerName)
        {
            RaiseEvent(new CustomerNameChanged { CustomerName = customerName });
        }
        public void AddOrderLine(string productName, int qty, decimal price)
        {
            RaiseEvent(new OrderLineAdded
            {
                ProductName = productName,
                QTY = qty,
                Price = price
            });


        }
        public void ProcessingOrder(ICustomerCreditLimitReached customerCreditLimitReached)
        {
            // make sure the customer is not over the limit
            if (customerCreditLimitReached.IsSatisfiedBy(this))
                throw new CustomerLimitReachedException(CustomerId, OrderId, TotalValue.HasValue ? TotalValue.Value : 0);

            RaiseEvent(new OrderProcessed { OrderStatus = Models.OrderStatus.Processing.ToString() });
        }
        public void AddPayment(DateTime paidOn, decimal amount, bool isSuccessful)
        {
            if (OrderStatus == OrderStatus.Draft) throw new Exception("Order is in Draft!");

            RaiseEvent(new PaymentAdded
            {
                PaymentDate = paidOn,
                PaymentAmount = amount,
                IsSuccessful = isSuccessful
            });
        }



        void When(OrderCreated e)
        {
            this.State.OrderId = e.OrderId.Id;
            this.State.CutomerId = e.CustomerId.ToString();

            this.State.OrderStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), e.OrderStatus);
            this.State.CustomerFullName = e.CustomerFullName;
            this.State.ShippingAddress = new Address
            {
                Address1 = e.ShippingAddress1,
                Address2 = e.ShippingAddress2,
                Suburb = e.ShippingSuburb,
                Postcode = e.ShippingPostcode,
                State = e.ShippingState,
                Country = e.ShippingCountry

            };
        }
        void When(CustomerNameChanged e)
        {
            this.State.CustomerFullName = e.CustomerName;
        }
        void When(OrderLineAdded e)
        {
            if (OrderLines == null) OrderLines = new Collection<OrderLine>();
            this.State.OrderLines.Add(new OrderLine
            {
                ProductName = e.ProductName,
                QTY = e.QTY,
                Price = e.Price
            });
        }
        void When(OrderProcessed e)
        {
            this.State.OrderStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), e.OrderStatus);
        }
        void When(PaymentAdded e)
        {
            if (OrderPayments == null) OrderPayments = new Collection<OrderPayment>();
            this.State.OrderPayments.Add(new OrderPayment
            {
                PaymentDate = e.PaymentDate,
                PaymentAmount = e.PaymentAmount,
                IsSuccessful = e.IsSuccessful
            });
        }
    }
}
