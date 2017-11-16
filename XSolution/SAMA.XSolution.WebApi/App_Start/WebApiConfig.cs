using Autofac;
using System.Reflection;
using System.Web.Http;
using Autofac.Integration.WebApi;
using MassTransit;
using MassTransit.Util;
using SAMA.Core.Logger;
using SAMA.XSolution.WebApi.Controllers;

namespace SAMA.XSolution.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = CreateContainer();


            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);


            var busControl = container.Resolve<IBusControl>();

            TaskUtil.Await(() => busControl.StartAsync());

            var ctl = container.Resolve(typeof(ValuesController));

        }

        static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<BusModule>();

            builder.RegisterModule<LoggerModule>();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            return builder.Build();
        }
    }
}
