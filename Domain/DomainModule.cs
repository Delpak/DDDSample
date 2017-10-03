using Autofac;
using BoundedContext.Domain.Model.Specifications;

namespace BoundedContext.Domain.Model
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DuplicateCustomerEmail>().As<IDuplicateCustomerEmail>();
            
        }
    }
}
