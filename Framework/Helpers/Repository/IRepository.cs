using System;
using System.Collections.Generic;
using SAMA.Framework.Common.Helpers.Domain;

namespace SAMA.Framework.Common.Helpers.Repository
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        TEntity FindById(Guid id);
        TEntity FindOne(Specification.ISpecification<TEntity> spec);
        IEnumerable<TEntity> Find(Specification.ISpecification<TEntity> spec);
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}