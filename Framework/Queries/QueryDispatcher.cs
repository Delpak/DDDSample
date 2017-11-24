using System;
using System.Threading.Tasks;
using SAMA.Core.DependencyResolver;
using SAMA.Framework.Common.Interfaces;

namespace SAMA.Framework.Common.Queries
{
    /// <summary>
    ///     <!--Weapsy.Framework.Queries-->
    /// </summary>
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IResolver _resolver;

        public QueryDispatcher(IResolver resolver)
        {
            _resolver = resolver;
        }

        public TResult Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            var queryHandler = GetHandler<IQueryHandler<TQuery, TResult>, TQuery>(query);

            return queryHandler.Retrieve(query);
        }

        public async Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            var queryHandler = GetHandler<IQueryHandlerAsync<TQuery, TResult>, TQuery>(query);

            return await queryHandler.RetrieveAsync(query);
        }

        public async Task<PagedQueryResult<TResult>> DispatchAsync_Paged<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            var queryHandler = GetHandler<IQueryHandlerAsync<TQuery, TResult>, TQuery>(query);

            return await queryHandler.Handle(query);
        }

        public PagedQueryResult<TResult> Dispatch_Paged<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            var queryHandler = GetHandler<IQueryHandler<TQuery, TResult>, TQuery>(query);

            return queryHandler.Handle(query);
        }

        private THandler GetHandler<THandler, TQuery>(TQuery query) where TQuery : IQuery
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var queryHandler = _resolver.Resolve<THandler>();

            if (queryHandler == null)
                throw new Exception($"No handler found for query '{query.GetType().FullName}'");

            return queryHandler;
        }
    }
}