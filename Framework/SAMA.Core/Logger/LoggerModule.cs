using Autofac;

namespace SAMA.Core.Logger
{
    public class LoggerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NLogLogger>().As<ILogger>().SingleInstance();
        }
    }
}
