using System.Linq;
using SAMA.FrameWork.Common;
using SAMA.XSolution.Domain.Infrastructure.Interfaces;
using SAMA.XSolution.Domain.Models;

namespace SAMA.XSolution.Domain.Specifications
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
