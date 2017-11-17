using System;
using Autofac;
using MassTransit;

namespace SAMA.XSolution.WebApi
{
    internal class BusModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context =>
                {
                    return Bus.Factory.CreateUsingRabbitMq(cfg =>
                    {
                        cfg.Host(new Uri("rabbitmq://localhost"), h =>
                        {
                            h.Username("guest");
                            h.Password("guest");
                        });
                    });
                })
                .As<IBus>()
                .As<IBusControl>()
                .SingleInstance();
        }
    }
}