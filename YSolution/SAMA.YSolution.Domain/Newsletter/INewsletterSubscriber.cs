using SAMA.YSolution.Domain.Customers;

namespace SAMA.YSolution.Domain.Newsletter
{
    public interface INewsletterSubscriber
    {
        void Subscribe(Customer customer);
    }
}