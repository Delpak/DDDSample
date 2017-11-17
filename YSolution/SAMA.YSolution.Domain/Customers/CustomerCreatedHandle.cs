using System.Net.Mail;
using SAMA.YSolution.Domain.Email;
using SAMA.YSolution.Domain.Helpers.Domain;
using SAMA.YSolution.Domain.Newsletter;

namespace SAMA.YSolution.Domain.Customers
{
    public class CustomerCreatedHandle : IHandles<CustomerCreated>
    {
        private readonly IEmailDispatcher emailDispatcher;
        private readonly INewsletterSubscriber newsletterSubscriber;

        public CustomerCreatedHandle(INewsletterSubscriber newsletterSubscriber, IEmailDispatcher emailDispatcher)
        {
            this.newsletterSubscriber = newsletterSubscriber;
            this.emailDispatcher = emailDispatcher;
        }

        public void Handle(CustomerCreated args)
        {
            //example #1 calling an interface email dispatcher this can have differnet kind of implementation depending on context, e.g
            // smtp = SmtpEmailDispatcher, exchange = ExchangeEmailDispatcher, msmq = MsmqEmailDispatcher, etc...
            emailDispatcher.Dispatch(new MailMessage());

            //example #2 calling an interface newsletter subscriber  this can differnet kind of implementation e.g
            // web service = WSNewsletterSubscriber (current), msmq = MsmqNewsletterSubscriber, Sql = SqlNewsletterSubscriber, etc...
            newsletterSubscriber.Subscribe(args.Customer);
        }
    }
}