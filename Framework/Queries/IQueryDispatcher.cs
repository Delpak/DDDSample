using System.Threading.Tasks;
using SAMA.Framework.Common.Interfaces;

namespace SAMA.Framework.Common.Queries
{
    public interface IQueryDispatcher
    {
        TResult Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery;
        PagedQueryResult<TResult> Dispatch_Paged<TQuery, TResult>(TQuery query) where TQuery : IQuery;

        Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery;
        Task<PagedQueryResult<TResult>> DispatchAsync_Paged<TQuery, TResult>(TQuery query) where TQuery : IQuery;
    }
}
