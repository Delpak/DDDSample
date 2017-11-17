using System;
using System.Linq.Expressions;
using SAMA.Framework.Common.Helpers.Specification;
using SAMA.YSolution.Domain.Carts;

namespace SAMA.YSolution.Domain.Products
{
    public class ProductIsInStockSpec : SpecificationBase<Product>
    {
        private readonly CartProduct productCart;

        public ProductIsInStockSpec(CartProduct productCart)
        {
            this.productCart = productCart;
        }

        public override Expression<Func<Product, bool>> SpecExpression
        {
            get
            {
                return product => product.Id == productCart.ProductId && product.Active
                                  && product.Quantity >= productCart.Quantity;
            }
        }
    }
}