using System.ComponentModel.DataAnnotations.Schema;
using SAMA.Framework.Common.Domain.Model;

namespace SAMA.XSolution.Domain.Models
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