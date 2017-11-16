using System;

namespace SAMA.XSolution.Messages.Commands
{
    public class CreateCustomerCommand
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }


}
