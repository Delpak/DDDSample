using System;
using System.Configuration;
using Autofac;
using Domain;
using Domain.Storage.EF;
using GreenPipes;
using Host.Masstransit.Consumers;
using MassTransit;
using Topshelf;

namespace Host.Masstransit
{
    internal class SampleBoundedContextService : ServiceControl
    {
        IBusControl _bus;

        public bool Start(HostControl hostControl)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<CreateCustomerConsumer>();
            containerBuilder.RegisterType<CreateOrerConsumer>();

            containerBuilder.Register(context =>
            {
                return Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var host = cfg.Host(GetHostAddress(), hostConfiguration =>
                    {
                        hostConfiguration.Username(ConfigurationManager.AppSettings["RabbitMQPassword"]);
                        hostConfiguration.Password(ConfigurationManager.AppSettings["RabbitMQPassword"]);
                    });

                    //cfg.UseTransaction(x =>
                    //{
                    //    x.Timeout = TimeSpan.FromSeconds(90);
                    //    x.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                    //});

                    //TODO: ReciveEndpoint Shutdown
                    cfg.ReceiveEndpoint(host, "BoundedContextOne_queue", e =>
                    {
                        e.LoadFrom(context);
                    });
                });
            }).SingleInstance()
                .As<IBusControl>()
                .As<IBus>();

            containerBuilder.RegisterModule<DomainStorageModule>();
            containerBuilder.RegisterModule<DomainModule>();

            var container = containerBuilder.Build();
            _bus = container.Resolve<IBusControl>();

            _bus.Start();

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _bus?.Stop(TimeSpan.FromSeconds(30));

            return true;
        }

        static Uri GetHostAddress()
        {
            var uriBuilder = new UriBuilder
            {
                Scheme = "rabbitmq",
                Host = ConfigurationManager.AppSettings["RabbitMQHost"]
            };

            return uriBuilder.Uri;
        }
    }
}