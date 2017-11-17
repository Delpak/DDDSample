using System;
using System.Linq.Expressions;
using SAMA.Framework.Common.Helpers.Specification;

namespace SAMA.YSolution.Domain.Customers
{
    public class CustomerRegisteredSpec : SpecificationBase<Customer>
    {
        private readonly Guid id;

        public CustomerRegisteredSpec(Guid id)
        {
            this.id = id;
        }

        public override Expression<Func<Customer, bool>> SpecExpression
        {
            get { return customer => customer.Id == id; }
        }
    }
}