using System;
using System.Linq;
using System.Linq.Expressions;
using SAMA.YSolution.Domain.Helpers.Specification;

namespace SAMA.YSolution.Domain.Products
{
    public class ProductReturnReasonSpec : SpecificationBase<Product>
    {
        private readonly ReturnReason returnReason;

        public ProductReturnReasonSpec(ReturnReason returnReason)
        {
            this.returnReason = returnReason;
        }

        public override Expression<Func<Product, bool>> SpecExpression
        {
            get { return product => product.Returns.ToList().Exists(returns => returns.Reason == returnReason); }
        }
    }
}