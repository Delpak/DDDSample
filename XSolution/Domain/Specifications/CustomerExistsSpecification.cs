using System.Linq;
using BoundedContext.Domain.Model.Infrastructure.Interfaces;
using BoundedContext.Domain.Model.Models;
using SAMA.FrameWork.Common;

namespace BoundedContext.Domain.Model.Specifications
{
    public class CustomerExistsSpecification : ICustomerExistsSpecification
    {
        readonly IRepository _repository;
        

        public CustomerExistsSpecification(IRepository repository)
        {
            _repository = repository;
            
        }

        public bool IsSatisfiedBy(Order entity)
        {
            return _repository.Project<Customer, bool>(customers => customers.Any(x => x.CustomerId == entity.CustomerId));
        }
    }

    public interface ICustomerExistsSpecification : ISpecification<Order>
    {
    }
}
