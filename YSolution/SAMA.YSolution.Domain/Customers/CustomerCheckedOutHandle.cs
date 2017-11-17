using SAMA.YSolution.Domain.Email;
using SAMA.YSolution.Domain.Helpers.Domain;

namespace SAMA.YSolution.Domain.Customers
{
    public class CustomerCheckedOutHandle : IHandles<CustomerCheckedOut>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IEmailDispatcher emailDispatcher;
        private readonly IEmailGenerator emailGenerator;

        public CustomerCheckedOutHandle(IEmailGenerator emailGenerator,
            IEmailDispatcher emailSender, ICustomerRepository customerRepository)
        {
            emailDispatcher = emailSender;
            this.emailGenerator = emailGenerator;
            this.customerRepository = customerRepository;
        }

        public void Handle(CustomerCheckedOut args)
        {
            var customer = customerRepository.FindById(args.Purchase.CustomerId);

            emailDispatcher.Dispatch(
                emailGenerator.Generate(customer, EmailTemplate.PurchaseMade)
            );

            //send notifications, update third party systems, etc
        }
    }
}