using System;

namespace SAMA.XSolution.Messages.Events
{
    public interface IOrderCreated
    {
        Guid OrderId { get; set; }
    }
}
