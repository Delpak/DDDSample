using System.Configuration;
using Autofac;
using SAMA.Framework.Common.Interfaces;

namespace SAMA.XSolution.Repository.EF
{
    public class DomainStorageModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SAMA.XSolution.Repository.EF.Repository>().As<IRepository>();
            builder.RegisterType<AppContext>().As<IApplicationContext>()
                .WithParameter("connectionString", ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        }
    }

}
