using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;
using MassTransit;
using Messages.Commands;

namespace WebApi.Controllers
{
    public class ValuesController : EnhancedApiController
    {
        
        [HttpGet]
        public async Task<IHttpActionResult> CreateCustomer()
        {
            var endpointAddress = new Uri(ConfigurationManager.AppSettings["BoundedContextOne_queue"]);

            var endpoint = await Bus.GetSendEndpoint(endpointAddress);

            var rnd = new Random().Next(1000);

            var request = new CreateCustomerCommand()
            {
                CustomerId = Guid.NewGuid(),
                Email = $"email{rnd}@company.com",
                FirstName = $"FirstName_{rnd}",
                LastName = $"LastName_{rnd}"
            };

            await endpoint.Send(request);

            return Ok("Success!");
        }
        [HttpGet]
        public async Task<IHttpActionResult> CreateOrder()
        {
            var endpointAddress = new Uri(ConfigurationManager.AppSettings["BoundedContextOne_queue"]);

            var endpoint = await Bus.GetSendEndpoint(endpointAddress);
            var rnd = new Random().Next(1000);
            var request = new CreateOrderCommand()
            {
                CustomerId = Guid.NewGuid(),
                Email = $"email{rnd}@company.com",
                FirstName = $"FirstName_{rnd}",
                LastName = $"LastName_{rnd}"
            };

            await endpoint.Send(request);

            return Ok("Success!");
        }

        public ValuesController(IBus bus) : base(bus)
        {
        }
    }
}
