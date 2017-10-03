using System.Configuration;
using Autofac;
using BoundedContext.Domain.Model.Infrastructure.Interfaces;

namespace DDDSample.Repository.EF
{
    public class DomainStorageModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Repository>().As<IRepository>();
            builder.RegisterType<AppContext>().As<IAppContext>()
                .WithParameter("connectionString", ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        }
    }

}
