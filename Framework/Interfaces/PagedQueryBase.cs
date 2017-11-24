using SAMA.Framework.Common.Queries;

namespace SAMA.Framework.Common.Interfaces
{
    public abstract class PagedQueryBase : IQuery
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}