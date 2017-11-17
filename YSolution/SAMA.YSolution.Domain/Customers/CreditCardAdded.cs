using SAMA.Framework.Common.Helpers.Domain;

namespace SAMA.YSolution.Domain.Customers
{
    public class CreditCardAdded : DomainEvent
    {
        public CreditCard CreditCard { get; set; }

        public override void Flatten()
        {
            Args.Add("CustomerId", CreditCard.Customer.Id);
            Args.Add("NameOnCard", CreditCard.NameOnCard);
            Args.Add("Last3Digits", CreditCard.CardNumber.Substring(CreditCard.CardNumber.Length - 3, 3));
        }
    }
}