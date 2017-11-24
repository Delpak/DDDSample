using SAMA.Framework.Common.Interfaces;

namespace SAMA.Framework.Common.Queries
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery
    {
        TResult Retrieve(TQuery query);
        PagedQueryResult<TResult> Handle(TQuery query);


    }
}
