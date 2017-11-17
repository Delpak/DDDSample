using Autofac;
using SAMA.XSolution.Domain.Specifications;

namespace SAMA.XSolution.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DuplicateCustomerEmail>().As<IDuplicateCustomerEmail>();
            
        }
    }
}
