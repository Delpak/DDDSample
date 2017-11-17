using System;

namespace SAMA.YSolution.Domain.Helpers.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
    }
}