using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Domain.Infrastructure.Interfaces;
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
