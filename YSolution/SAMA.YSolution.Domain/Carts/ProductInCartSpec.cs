using System;
using System.Linq.Expressions;
using SAMA.Framework.Common.Helpers.Specification;
using SAMA.YSolution.Domain.Products;

namespace SAMA.YSolution.Domain.Carts
{
    public class ProductInCartSpec : SpecificationBase<CartProduct>
    {
        private readonly Product product;

        public ProductInCartSpec(Product product)
        {
            this.product = product;
        }

        public override Expression<Func<CartProduct, bool>> SpecExpression
        {
            get { return cartProduct => cartProduct.ProductId == product.Id; }
        }
    }
}