using System;
using System.Collections.Generic;
using System.Linq;
using SAMA.Framework.Common;
using SAMA.XSolution.Domain.Models;

namespace SAMA.XSolution.Repository.EF
{

    public class OrderRepository : GenericRepository<OrderState>, IOrderRepository
    {
        private readonly IApplicationContext _context;
        
        public void Add(Order product)
        {
            //throw new NotImplementedException();
        }

        public Order OrderOfId(OrderId orderId)
        {
            var state = default(OrderState);

            try
            {
                state = (from p in
                        _context.Orders
                    where
                        p.OrderId == orderId.Id
                    select p).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine("ProductOfId() Unexpected: " + e);
            }

            if (EqualityComparer<OrderState>.Default.Equals(state, default(OrderState)))
            {
                return null;
            }
            return new Order(state);
            
        }

        public OrderRepository(IApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}