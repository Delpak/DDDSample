using System.Configuration;
using Autofac;
using Domain.Infrastructure.Interfaces;

namespace Domain.Storage.EF
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
