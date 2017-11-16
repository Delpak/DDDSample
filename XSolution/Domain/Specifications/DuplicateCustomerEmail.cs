using System.Linq;
using BoundedContext.Domain.Model.Infrastructure.Interfaces;
using BoundedContext.Domain.Model.Models;
using SAMA.FrameWork.Common;

namespace BoundedContext.Domain.Model.Specifications
{
    public class DuplicateCustomerEmail : IDuplicateCustomerEmail
    {
        readonly IRepository _repository;
        

        public DuplicateCustomerEmail(IRepository repository)
        {
            _repository = repository;
        }

        public bool IsSatisfiedBy(Customer entity)
        {
            // customer must have a unique email address
            var anyCustomer = _repository.Project<Customer, bool>(customers => customers.Any(x => x.Email == entity.Email));
            return anyCustomer;
        }
    }

    public interface IDuplicateCustomerEmail : ISpecification<Customer>
    {
    }
}
