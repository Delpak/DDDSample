using System;
using System.Linq.Expressions;
using SAMA.Framework.Common.Helpers.Specification;

namespace SAMA.YSolution.Domain.Customers
{
    public class CustomerAlreadyRegisteredSpec : SpecificationBase<Customer>
    {
        private readonly string _email;

        public CustomerAlreadyRegisteredSpec(string email)
        {
            _email = email;
        }

        public override Expression<Func<Customer, bool>> SpecExpression
        {
            get { return customer => customer.Email == _email; }
        }
    }
}