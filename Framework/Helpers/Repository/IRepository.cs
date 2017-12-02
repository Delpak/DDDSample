using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SAMA.Framework.Common.Helpers.Domain;

namespace SAMA.Framework.Common.Helpers.Repository
{
    public interface IRepository<T, in TKey> where T : IAggregateRoot<TKey>
    {
        T GetById(TKey id);
        T GetSingleBySpec(Specification.ISpecification<T> spec);
        IEnumerable<T> ListAll();
        IEnumerable<T> List(Specification.ISpecification<T> spec);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}