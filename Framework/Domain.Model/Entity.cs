using System;
using System.ComponentModel.DataAnnotations;
using SAMA.Framework.Common.Helpers.Domain;

namespace SAMA.Framework.Common.Domain.Model
{
    public abstract class Entity<TKey> : IAggregateRoot<TKey>
    {
        [Timestamp]
        public byte[] Timestamp { get; set; }

        public TKey Id { get; }
    }
}
