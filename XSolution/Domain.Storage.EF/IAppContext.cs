using System.Data.Entity;
using SAMA.Framework.Common;
using SAMA.XSolution.Domain.Models;

namespace SAMA.XSolution.Repository.EF
{
    public interface IApplicationContext : IAppContext
    {
        IDbSet<OrderState> Orders { get; set; }
        IDbSet<CustomerState> Customers { get; set; }
    }
}