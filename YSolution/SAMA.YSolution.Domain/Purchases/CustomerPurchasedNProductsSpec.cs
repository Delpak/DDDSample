using System;
using System.Linq.Expressions;
using SAMA.Framework.Common.Helpers.Specification;

namespace SAMA.YSolution.Domain.Purchases
{
    public class PurchasedNProductsSpec : SpecificationBase<Purchase>
    {
        private readonly int nProducts;

        public PurchasedNProductsSpec(int nProducts)
        {
            this.nProducts = nProducts;
        }

        public override Expression<Func<Purchase, bool>> SpecExpression
        {
            get { return purchase => purchase.Products.Count >= nProducts; }
        }
    }
}