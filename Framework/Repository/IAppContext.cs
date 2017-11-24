using System;

namespace SAMA.Framework.Common
{
    public interface IAppContext : IDisposable
    {
        int SaveChanges();
    }
}