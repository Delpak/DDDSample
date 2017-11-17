using System.Collections.Generic;
using SAMA.Framework.Common.Helpers.Repository;

namespace SAMA.YSolution.Domain.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<CustomerPurchaseHistoryReadModel> GetCustomersPurchaseHistory();
    }
}