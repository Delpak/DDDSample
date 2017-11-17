using System;

namespace SAMA.YSolution.Domain.Customers
{
    public class CustomerPurchaseHistoryReadModel
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TotalPurchases { get; set; }
        public int TotalProductsPurchased { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalTax { get; set; }
    }
}