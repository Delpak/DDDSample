using System;
using SAMA.XSolution.Domain.Models;

namespace SAMA.XSolution.Domain.Exceptions
{
    public class CustomerLimitReachedException : Exception
    {
        public CustomerId CustomerId { get; private set; }
        public OrderId OrderId { get; private set; }
        public decimal OrderValue { get; private set; }

        public CustomerLimitReachedException(CustomerId customerId, OrderId orderId, decimal orderValue)
        {
            CustomerId = customerId;
            OrderId = orderId;
            OrderValue = orderValue;
        }
    }
}
