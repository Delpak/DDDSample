using NServiceBus.Testing;
using NUnit.Framework;
using SAMA.XSolution.Handlers;
using SAMA.XSolution.Messages.Events;

namespace Handlers.Tests
{
    public class NSBBaseTest
    {
        [SetUp]
        public void Startup()
        {
            Test.Initialize(configuration =>
                            {
                                configuration.AssembliesToScan(typeof(ICustomerCreated).Assembly, typeof(CustomerHandler).Assembly);
                                configuration.OverrideLocalAddress("DDDSample.Handlers.Tests");
                                configuration.Conventions().UseDDDSampleConventions();
                            });
        }
    }
}