using SAMA.Framework.Common.Helpers.Domain;

namespace SAMA.YSolution.Domain.Carts
{
    public class CartCreated : DomainEvent
    {
        public Cart Cart { get; set; }

        public override void Flatten()
        {
            Args.Add("CustomerId", Cart.CustomerId);
            Args.Add("CartId", Cart.Id);
        }
    }
}