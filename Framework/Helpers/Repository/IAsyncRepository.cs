using System.Collections.Generic;
using System.Threading.Tasks;
using SAMA.Framework.Common.Helpers.Domain;

namespace SAMA.Framework.Common.Helpers.Repository
{
    public interface IAsyncRepository<T> where T : IAggregateRoot
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAsync(SAMA.Framework.Common.Helpers.Specification.ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}