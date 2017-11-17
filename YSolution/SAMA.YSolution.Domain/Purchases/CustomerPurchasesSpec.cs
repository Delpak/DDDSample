using System;
using System.Linq.Expressions;
using SAMA.YSolution.Domain.Helpers.Specification;

namespace SAMA.YSolution.Domain.Purchases
{
    public class CustomerPurchasesSpec : SpecificationBase<Purchase>
    {
        private readonly Guid customerId;

        public CustomerPurchasesSpec(Guid customerId)
        {
            this.customerId = customerId;
        }

        public override Expression<Func<Purchase, bool>> SpecExpression
        {
            get { return purchase => purchase.CustomerId == customerId; }
        }
    }
}