using System;

namespace DDDSample.Common.Domain.Model
{
    public abstract class Identity<T> : IEquatable<Identity<T>>, IIdentity<T>
    {
        protected Identity()
        {
            Id = default(T);
        }

        protected Identity(T id)
        {
            Id = id;
        }

        public T Id { get; set; }

        public bool Equals(Identity<T> id)
        {
            if (object.ReferenceEquals(this, id)) return true;
            if (object.ReferenceEquals(null, id)) return false;
            return this.Id.Equals(id.Id);
        }

        public override bool Equals(object anotherObject)
        {
            return Equals(anotherObject as Identity<T>);
        }

        public override int GetHashCode()
        {
            return (this.GetType().GetHashCode() * 907) + this.Id.GetHashCode();
        }

        public override string ToString()
        {
            return this.GetType().Name + " [Id=" + Id + "]";
        }
    }
}
