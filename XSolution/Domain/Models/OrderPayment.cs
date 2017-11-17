using System;

namespace SAMA.XSolution.Domain.Models
{
    public class OrderPayment
    {
        public int OrderPaymentId { get; set; }
        public Guid OrderId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public bool IsSuccessful { set; get; }
    }
}