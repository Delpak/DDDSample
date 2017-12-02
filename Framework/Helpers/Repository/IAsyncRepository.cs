using System.Collections.Generic;
using System.Threading.Tasks;
using SAMA.Framework.Common.Helpers.Domain;

namespace SAMA.Framework.Common.Helpers.Repository
{
    public interface IAsyncRepository<T, in TKey> where T : IAggregateRoot<TKey>
    {
        Task<T> GetByIdAsync(TKey id);
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAsync(Specification.ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}