using System;
using System.Linq.Expressions;
using SAMA.YSolution.Domain.Helpers.Specification;

namespace SAMA.YSolution.Domain.Customers
{
    public class CreditCardAvailableSpec : SpecificationBase<CreditCard>
    {
        private readonly DateTime dateTime;

        public CreditCardAvailableSpec(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public override Expression<Func<CreditCard, bool>> SpecExpression
        {
            get { return creditCard => creditCard.Active && creditCard.Expiry >= dateTime; }
        }
    }
}