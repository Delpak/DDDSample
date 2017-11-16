using System;

namespace BoundedContext.Domain.Model.Models
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public Guid OrderId { get; set; }
        public string ProductName { get; set; }
        public int QTY { get; set; }
        public decimal Price { get; set; }

    }
}