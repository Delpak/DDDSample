using BoundedContext.Domain.Model.Models;

namespace BoundedContext.Domain.Model.Events.Orders
{
    public class OrderCreated
    {
        public OrderId OrderId { get; set; }
        public CustomerId CustomerId { get; set; }
        public string CustomerFullName { get; set; }
        public string OrderStatus { get; set; }
        public string ShippingAddress1 { get; set; }
        public string ShippingAddress2 { get; set; }
        public string ShippingSuburb { get; set; }
        public string ShippingPostcode { get; set; }
        public string ShippingState { get; set; }
        public string ShippingCountry { get; set; }
    }
}
