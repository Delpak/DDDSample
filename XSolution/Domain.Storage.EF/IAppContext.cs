using System;
using System.Data.Entity;
using SAMA.XSolution.Domain.Models;

namespace SAMA.XSolution.Repository.EF
{
    public interface IAppContext:IDisposable
    {
        IDbSet<OrderState> Orders { get; set; }
        IDbSet<CustomerState> Customers { get; set; }

        int SaveChanges();
    }
}