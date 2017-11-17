using System;
using System.Collections.Generic;

namespace SAMA.YSolution.ApplicationService
{
    public interface ICustomerService
    {
        bool IsEmailAvailable(string email);
        CustomerDto Add(CustomerDto customerDto);
        void Update(CustomerDto customerDto);
        void Remove(Guid customerId);
        CustomerDto Get(Guid customerId);
        CreditCardDto Add(Guid customerId, CreditCardDto creditCard);
        List<CustomerPurchaseHistoryDto> GetAllCustomerPurchaseHistoryV1();

        List<CustomerPurchaseHistoryDto> GetAllCustomerPurchaseHistoryV2();
    }

    public class CustomerPurchaseHistoryDto
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int TotalPurchases { get; set; }
        public int TotalProductsPurchased { get; set; }
        public decimal TotalCost { get; set; }
    }
}