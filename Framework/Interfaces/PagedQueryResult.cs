using System;

namespace SAMA.Framework.Common.Interfaces
{
    public sealed class PagedQueryResult<TResult>
    {
        public TResult[] Results { get; set; }
        public int TotalFound { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get { return PageSize != 0 ? (int)Math.Ceiling((decimal)TotalFound / PageSize) : 0; } }
    }
}