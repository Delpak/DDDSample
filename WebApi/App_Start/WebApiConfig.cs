using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using MassTransit;
using MassTransit.Util;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = CreateContainer();

            
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);


            var busControl = container.Resolve<IBusControl>();

            TaskUtil.Await(() => busControl.StartAsync());

        }

        static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<BusModule>();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            return builder.Build();
        }
    }
    
}
