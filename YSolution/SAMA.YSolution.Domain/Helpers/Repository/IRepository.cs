using System;
using System.Collections.Generic;
using SAMA.YSolution.Domain.Helpers.Domain;
using SAMA.YSolution.Domain.Helpers.Specification;

namespace SAMA.YSolution.Domain.Helpers.Repository
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        TEntity FindById(Guid id);
        TEntity FindOne(ISpecification<TEntity> spec);
        IEnumerable<TEntity> Find(ISpecification<TEntity> spec);
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}