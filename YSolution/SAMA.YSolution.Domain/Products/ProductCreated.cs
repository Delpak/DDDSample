using SAMA.Framework.Common.Helpers.Domain;

namespace SAMA.YSolution.Domain.Products
{
    public class ProductCreated : DomainEvent
    {
        public Product Product { get; set; }

        public override void Flatten()
        {
            Args.Add("ProductId", Product.Id);
            Args.Add("ProductName", Product.Name);
            Args.Add("ProductQuantity", Product.Quantity);
            Args.Add("ProductCode", Product.Code.Id);
            Args.Add("ProductCost", Product.Cost);
        }
    }
}