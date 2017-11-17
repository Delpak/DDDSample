using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SAMA.YSolution.Domain.Helpers.Specification;

namespace SAMA.YSolution.Domain.Customers
{
    public class CustomerBulkIdFindSpec : SpecificationBase<Customer>
    {
        private readonly IEnumerable<Guid> customerIds;

        public CustomerBulkIdFindSpec(IEnumerable<Guid> customerIds)
        {
            this.customerIds = customerIds;
        }

        public override Expression<Func<Customer, bool>> SpecExpression
        {
            get { return customer => customerIds.Contains(customer.Id); }
        }
    }
}