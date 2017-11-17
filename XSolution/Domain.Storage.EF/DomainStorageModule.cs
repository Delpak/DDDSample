using System.Configuration;
using Autofac;
using SAMA.XSolution.Domain.Infrastructure.Interfaces;
using SAMA.XSolution.Repository.EF;

namespace DDDSample.Repository.EF
{
    public class DomainStorageModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SAMA.XSolution.Repository.EF.Repository>().As<IRepository>();
            builder.RegisterType<AppContext>().As<IAppContext>()
                .WithParameter("connectionString", ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        }
    }

}
