using SAMA.Framework.Common.Helpers.Domain;

namespace SAMA.YSolution.Domain.Customers
{
    public class CustomerChangedEmail : DomainEvent
    {
        public Customer Customer { get; set; }

        public override void Flatten()
        {
            Args.Add("CustomerId", Customer.Id);
            Args.Add("Email", Customer.Email);
        }
    }
}