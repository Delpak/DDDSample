using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoundedContext.Domain.Model.Models
{
    public class OrderState : IAggregateState
    {
        [Key]
        public Guid OrderId { get; set; }
        public string CutomerId { get; set; }
        public string CustomerFullName { get; set; }
        public string Address1 { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Address ShippingAddress { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
        public ICollection<OrderPayment> OrderPayments { get; set; }

        [MaxLength(200)]
        public string Address2 { get; set; }

        public string Suburb { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public int? TotalValue { get; set; }
        public int? TotalPaid { get; set; }
    }

    public interface IAggregateState
    {
    }
}