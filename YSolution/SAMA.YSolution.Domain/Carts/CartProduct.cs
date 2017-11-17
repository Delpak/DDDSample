using System;
using SAMA.YSolution.Domain.Customers;
using SAMA.YSolution.Domain.Products;
using SAMA.YSolution.Domain.Services;

namespace SAMA.YSolution.Domain.Carts
{
    public class CartProduct
    {
        public virtual Guid CartId { get; protected set; }
        public virtual Guid CustomerId { get; protected set; }
        public virtual int Quantity { get; protected set; }
        public virtual Guid ProductId { get; protected set; }
        public virtual DateTime Created { get; protected set; }
        public virtual decimal Cost { get; protected set; }
        public virtual decimal Tax { get; set; }

        public static CartProduct Create(Customer customer, Cart cart, Product product, int quantity,
            TaxService taxService)
        {
            if (cart == null)
                throw new ArgumentNullException("cart");

            if (product == null)
                throw new ArgumentNullException("product");

            var cartProduct = new CartProduct
            {
                CustomerId = customer.Id,
                CartId = cart.Id,
                ProductId = product.Id,
                Quantity = quantity,
                Created = DateTime.Now,
                Cost = product.Cost,
                Tax = taxService.Calculate(customer, product)
            };

            return cartProduct;
        }
    }
}