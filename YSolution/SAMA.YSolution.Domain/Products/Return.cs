using System;
using SAMA.YSolution.Domain.Customers;

namespace SAMA.YSolution.Domain.Products
{
    public class Return
    {
        public virtual Product Product { get; protected set; }
        public virtual Customer Customer { get; protected set; }
        public virtual ReturnReason Reason { get; protected set; }
        public virtual DateTime Created { get; protected set; }
        public virtual string Note { get; protected set; }
    }
}