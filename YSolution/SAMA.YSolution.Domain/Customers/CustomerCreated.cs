using SAMA.YSolution.Domain.Helpers.Domain;

namespace SAMA.YSolution.Domain.Customers
{
    public class CustomerCreated : DomainEvent
    {
        public Customer Customer { get; set; }

        public override void Flatten()
        {
            Args.Add("FirstName", Customer.FirstName);
            Args.Add("LastName", Customer.LastName);
            Args.Add("Email", Customer.Email);
            Args.Add("Country", Customer.CountryId);
        }
    }
}