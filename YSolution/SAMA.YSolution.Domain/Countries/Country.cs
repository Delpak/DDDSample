using System;
using SAMA.Framework.Common.Helpers.Domain;

namespace SAMA.YSolution.Domain.Countries
{
    public class Country : IAggregateRoot
    {
        public string Name { get; protected set; }
        public Guid Id { get; protected set; }

        public static Country Create(string name)
        {
            return Create(Guid.NewGuid(), name);
        }

        public static Country Create(Guid id, string name)
        {
            var country = new Country
            {
                Id = id,
                Name = name
            };

            DomainEvents.Raise(new CountryCreated {Country = country});

            return country;
        }
    }
}