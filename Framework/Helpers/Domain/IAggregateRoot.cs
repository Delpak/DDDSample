using System;

namespace SAMA.Framework.Common.Helpers.Domain
{
    public interface IAggregateRoot<out TKey>
    {
        TKey Id { get; }
    }
}