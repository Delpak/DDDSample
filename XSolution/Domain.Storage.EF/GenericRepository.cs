using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SAMA.XSolution.Domain.Models;
using SAMA.XSolution.Repository.EF;

namespace DDDSample.Repository.EF
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, IAggregateState
    {
        protected IAppContext Entities;
        protected readonly IDbSet<T> Dbset;

        protected GenericRepository(IAppContext context)
        {
            Entities = context;
            Dbset = ((DbContext)context).Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {

            return Dbset.AsEnumerable<T>();
        }

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IEnumerable<T> query = Dbset.Where(predicate).AsEnumerable();
            return query;
        }

        public virtual T Add(T entity)
        {
            return Dbset.Add(entity);
        }

        public virtual T Delete(T entity)
        {
            return Dbset.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            ((DbContext)Entities).Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void Save()
        {
            Entities.SaveChanges();
        }
    }
}