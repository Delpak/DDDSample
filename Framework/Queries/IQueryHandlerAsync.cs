using System.Threading.Tasks;
using SAMA.Framework.Common.Interfaces;

namespace SAMA.Framework.Common.Queries
{
    public interface IQueryHandlerAsync<in TQuery, TResult> where TQuery : IQuery
    {
        Task<TResult> RetrieveAsync(TQuery query);

        Task<PagedQueryResult<TResult>> Handle(TQuery query);

    }
}
