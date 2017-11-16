using System;
using System.Collections.Generic;
using System.Linq;
using BoundedContext.Domain.Model.Models;
using DDDSample.Repository.EF;

namespace SAMA.XSolution.Repository.EF
{

    public class OrderRepository : GenericRepository<OrderState>, IOrderRepository
    {
        private readonly IAppContext _context;
        
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

        public OrderRepository(IAppContext context) : base(context)
        {
            _context = context;
        }
    }
}