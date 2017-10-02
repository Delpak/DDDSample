using Autofac;
using Domain.Specifications;

namespace Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DuplicateCustomerEmail>().As<IDuplicateCustomerEmail>();
            
        }
    }
}
