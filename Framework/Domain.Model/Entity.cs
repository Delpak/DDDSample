using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SAMA.Framework.Common.Helpers.Domain;

namespace SAMA.Framework.Common.Domain.Model
{
    public abstract class Entity : IAggregateRoot
    {
        [Timestamp]
        public byte[] Timestamp { get; set; }

        public Guid Id { get; }
    }

    public abstract class EntityWithCompositeId : Entity
    {
        /// <summary>
        /// When overriden in a derived class, gets all components of the identity of the entity.
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<object> GetIdentityComponents();

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj)) return true;
            if (object.ReferenceEquals(null, obj)) return false;
            if (GetType() != obj.GetType()) return false;
            var other = obj as EntityWithCompositeId;
            return GetIdentityComponents().SequenceEqual(other.GetIdentityComponents());
        }

        public override int GetHashCode()
        {
            return HashCodeHelper.CombineHashCodes(GetIdentityComponents());
        }
    }

}
