using System;
using System.Linq;
using System.Linq.Expressions;
using SAMA.Framework.Common.Queries;

namespace SAMA.Framework.Common.Interfaces
{
    public interface IRepository
    {
        void Add<TAggregate>(TAggregate aggregate) where TAggregate : class;
        TAggregate Load<TAggregate>(Func<TAggregate, bool> predicate, params Expression<Func<TAggregate, object>>[] includes) where TAggregate : class;
        PagedQueryResult<TResult> Search<TResult>(IQuery query);
        TProjection Project<TAggregate, TProjection>(Func<IQueryable<TAggregate>, TProjection> query) where TAggregate : class;
    }
}