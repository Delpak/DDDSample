using System.ComponentModel.DataAnnotations.Schema;
using SAMA.FrameWork.Common.Domain.Model;

namespace BoundedContext.Domain.Model.Models
{
    [ComplexType]
    public class CustomerId : Identity<string>
    {
        protected CustomerId() { }
        public CustomerId(string id) : base(id)
        {
        }
    }
}