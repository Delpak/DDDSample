using System;

namespace SAMA.Framework.Common.Helpers.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
    }
}