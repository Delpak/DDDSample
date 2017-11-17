using System;
using System.Linq.Expressions;
using SAMA.Framework.Common.Helpers.Specification;

namespace SAMA.YSolution.Domain.Carts
{
    public class CustomerCartSpec : SpecificationBase<Cart>
    {
        private readonly Guid customerId;

        public CustomerCartSpec(Guid customerId)
        {
            this.customerId = customerId;
        }

        public override Expression<Func<Cart, bool>> SpecExpression
        {
            get { return cart => cart.CustomerId == customerId; }
        }
    }
}