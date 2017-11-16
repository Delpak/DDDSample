using System;
using System.ComponentModel.DataAnnotations;
using BoundedContext.Domain.Model.Exceptions;
using BoundedContext.Domain.Model.Specifications;
using SAMA.FrameWork.Common.Domain.Model;

namespace BoundedContext.Domain.Model.Models
{
    public class Customer : Entity
    {
        private readonly CustomerState _customerState;

        public CustomerId CustomerId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        public decimal? CustomerCreditLimit { get; private set; }

        protected Customer()
        {
            CustomerId = new CustomerId(Guid.NewGuid().ToString());
        }
        public Customer(CustomerId id, string firstName, string lastName, string email, IDuplicateCustomerEmail duplicateCustomerEmail)
        {
            CustomerId = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;

            if (duplicateCustomerEmail.IsSatisfiedBy(this))
                throw new DuplicateEmailException(email);
        }

        public Customer(CustomerState customerState)
        {
            this.CustomerId = new CustomerId(customerState.CustomerId);
            this.Email = customerState.Email;
            this.CustomerCreditLimit = CustomerCreditLimit;
            this.FirstName = customerState.FirstName;
            this.LastName = customerState.LastName;
        }
        public void SetCustomerOrderLimit(decimal? limit)
        {
            CustomerCreditLimit = limit;
        }
    }

    public class CustomerState
    {
        [Key]
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal? CustomerCreditLimit { get; set; }

    }
}
