using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SAMA.XSolution.Domain.Models
{
    //public interface IOrderRepository
    //{
    //    void Add(Order product);

    //    Order OrderOfId(OrderId orderId);
    //}

    public interface IGenericRepository<T> where T : IAggregateState
    {

        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        void Save();
    }


    public interface IOrderRepository : IGenericRepository<OrderState>
    {
        Order OrderOfId(OrderId orderId);
    }
}