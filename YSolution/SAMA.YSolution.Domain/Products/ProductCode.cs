using System;
using SAMA.YSolution.Domain.Helpers.Domain;

namespace SAMA.YSolution.Domain.Products
{
    public class ProductCode : IAggregateRoot
    {
        public string Name { get; protected set; }
        public Guid Id { get; protected set; }

        public static ProductCode Create(string name)
        {
            return Create(Guid.NewGuid(), name);
        }

        public static ProductCode Create(Guid id, string name)
        {
            var productCode = new ProductCode
            {
                Id = id,
                Name = name
            };

            DomainEvents.Raise(new ProductCodeCreated {ProductCode = productCode});

            return productCode;
        }
    }
}