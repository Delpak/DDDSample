using System;
using System.Data.Entity;
using BoundedContext.Domain.Model.Models;

namespace DDDSample.Repository.EF
{
    public interface IAppContext:IDisposable
    {
        IDbSet<OrderState> Orders { get; set; }
        IDbSet<CustomerState> Customers { get; set; }

        int SaveChanges();
    }
}