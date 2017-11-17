using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SAMA.Framework.Common.Helpers.Domain;
using SAMA.YSolution.Domain.Carts;

namespace SAMA.YSolution.Domain.Purchases
{
    public class Purchase : IAggregateRoot
    {
        private List<PurchasedProduct> purchasedProducts = new List<PurchasedProduct>();

        public ReadOnlyCollection<PurchasedProduct> Products => purchasedProducts.AsReadOnly();

        public DateTime Created { get; protected set; }
        public Guid CustomerId { get; protected set; }
        public decimal TotalTax { get; protected set; }
        public decimal TotalCost { get; protected set; }

        public Guid Id { get; protected set; }

        public static Purchase Create(Cart cart)
        {
            var purchase = new Purchase
            {
                Id = Guid.NewGuid(),
                Created = DateTime.Today,
                CustomerId = cart.CustomerId,
                TotalCost = cart.TotalCost,
                TotalTax = cart.TotalTax
            };

            var purchasedProducts = new List<PurchasedProduct>();
            foreach (var cartProduct in cart.Products)
                purchasedProducts.Add(PurchasedProduct.Create(purchase, cartProduct));

            purchase.purchasedProducts = purchasedProducts;

            return purchase;
        }
    }
}