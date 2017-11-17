using SAMA.YSolution.Domain.Helpers.Domain;
using SAMA.YSolution.Domain.Purchases;

namespace SAMA.YSolution.Domain.Customers
{
    public class CustomerCheckedOut : DomainEvent
    {
        public Purchase Purchase { get; set; }

        public override void Flatten()
        {
            Args.Add("CustomerId", Purchase.CustomerId);
            Args.Add("PurchaseId", Purchase.Id);
            Args.Add("TotalCost", Purchase.TotalCost);
            Args.Add("TotalTax", Purchase.TotalTax);
            Args.Add("NumberOfProducts", Purchase.Products.Count);
        }
    }
}