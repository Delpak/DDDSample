using System.Collections.Generic;
using SAMA.YSolution.Domain.Helpers.Repository;

namespace SAMA.YSolution.Domain.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<CustomerPurchaseHistoryReadModel> GetCustomersPurchaseHistory();
    }
}