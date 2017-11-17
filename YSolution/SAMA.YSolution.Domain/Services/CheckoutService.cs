using System;
using SAMA.YSolution.Domain.Carts;
using SAMA.YSolution.Domain.Customers;
using SAMA.YSolution.Domain.Helpers.Domain;
using SAMA.YSolution.Domain.Helpers.Repository;
using SAMA.YSolution.Domain.Helpers.Specification;
using SAMA.YSolution.Domain.Products;
using SAMA.YSolution.Domain.Purchases;

namespace SAMA.YSolution.Domain.Services
{
    public class CheckoutService : IDomainService
    {
        private ICustomerRepository customerRepository;
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<Purchase> purchaseRepository;

        public CheckoutService(ICustomerRepository customerRepository, IRepository<Purchase> purchaseRepository,
            IRepository<Product> productRepository)
        {
            this.customerRepository = customerRepository;
            this.purchaseRepository = purchaseRepository;
            this.productRepository = productRepository;
        }

        public PaymentStatus CustomerCanPay(Customer customer)
        {
            if (customer.Balance < 0)
                return PaymentStatus.UnpaidBalance;

            if (customer.GetCreditCardsAvailble().Count == 0)
                return PaymentStatus.NoActiveCreditCardAvailable;

            return PaymentStatus.OK;
        }

        public ProductState ProductCanBePurchased(Cart cart)
        {
            ISpecification<Product> faultyProductSpec = new ProductReturnReasonSpec(ReturnReason.Faulty);

            foreach (var cartProduct in cart.Products)
            {
                var product = productRepository.FindById(cartProduct.ProductId);
                if (product == null)
                    throw new Exception($"Product {cartProduct.ProductId} not found");

                var isInStock = new ProductIsInStockSpec(cartProduct).IsSatisfiedBy(product);

                if (!isInStock)
                    return ProductState.NotInStock;

                var isFaulty = faultyProductSpec.IsSatisfiedBy(product);

                if (isFaulty)
                    return ProductState.IsFaulty;
            }
            return ProductState.OK;
        }

        public CheckOutIssue? CanCheckOut(Customer customer, Cart cart)
        {
            var paymentStatus = CustomerCanPay(customer);
            if (paymentStatus != PaymentStatus.OK)
                return (CheckOutIssue) paymentStatus;

            var productState = ProductCanBePurchased(cart);
            if (productState != ProductState.OK)
                return (CheckOutIssue) productState;

            return null;
        }

        public Purchase Checkout(Customer customer, Cart cart)
        {
            var checkoutIssue = CanCheckOut(customer, cart);
            if (checkoutIssue.HasValue)
                throw new Exception(checkoutIssue.Value.ToString());

            var purchase = Purchase.Create(cart);

            purchaseRepository.Add(purchase);

            cart.Clear();

            DomainEvents.Raise(new CustomerCheckedOut {Purchase = purchase});

            return purchase;
        }
    }
}