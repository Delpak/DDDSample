using SAMA.Framework.Common.Helpers.Domain;
using SAMA.YSolution.Domain.Email;

namespace SAMA.YSolution.Domain.Customers
{
    public class CustomerCheckedOutHandle : IHandles<CustomerCheckedOut>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailDispatcher _emailDispatcher;
        private readonly IEmailGenerator _emailGenerator;

        public CustomerCheckedOutHandle(IEmailGenerator emailGenerator, IEmailDispatcher emailSender, ICustomerRepository customerRepository)
        {
            _emailDispatcher = emailSender;
            this._emailGenerator = emailGenerator;
            this._customerRepository = customerRepository;
        }

        public void Handle(CustomerCheckedOut args)
        {
            var customer = _customerRepository.FindById(args.Purchase.CustomerId);

            _emailDispatcher.Dispatch(
                _emailGenerator.Generate(customer, EmailTemplate.PurchaseMade)
            );

            //send notifications, update third party systems, etc
        }
    }
}