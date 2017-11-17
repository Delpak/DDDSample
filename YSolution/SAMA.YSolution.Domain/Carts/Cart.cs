using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SAMA.Framework.Common.Helpers.Domain;
using SAMA.YSolution.Domain.Customers;
using SAMA.YSolution.Domain.Products;

namespace SAMA.YSolution.Domain.Carts
{
    public class Cart : IAggregateRoot
    {
        private readonly List<CartProduct> _cartProducts = new List<CartProduct>();

        public virtual ReadOnlyCollection<CartProduct> Products => _cartProducts.AsReadOnly();

        public virtual Guid CustomerId { get; protected set; }

        public virtual decimal TotalCost
        {
            get { return Products.Sum(cartProduct => cartProduct.Quantity * cartProduct.Cost); }
        }

        public virtual decimal TotalTax
        {
            get { return Products.Sum(cartProducts => cartProducts.Tax); }
        }

        public virtual Guid Id { get; protected set; }

        public static Cart Create(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            var cart = new Cart();
            cart.Id = Guid.NewGuid();
            cart.CustomerId = customer.Id;

            DomainEvents.Raise(new CartCreated {Cart = cart});

            return cart;
        }

        public virtual void Add(CartProduct cartProduct)
        {
            if (cartProduct == null)
                throw new ArgumentNullException();

            DomainEvents.Raise(new ProductAddedCart {CartProduct = cartProduct});

            _cartProducts.Add(cartProduct);
        }

        public virtual void Remove(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product");

            var cartProduct =
                _cartProducts.Find(new ProductInCartSpec(product).IsSatisfiedBy);

            DomainEvents.Raise(new ProductRemovedCart {CartProduct = cartProduct});

            _cartProducts.Remove(cartProduct);
        }

        public virtual void Clear()
        {
            _cartProducts.Clear();
        }
    }
}