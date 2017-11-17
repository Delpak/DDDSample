using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;
using MassTransit;
using SAMA.XSolution.Messages.Commands;

namespace SAMA.XSolution.WebApi.Controllers
{
    public class ValuesController : BaseApiController
    {

        [HttpGet]
        public async Task<IHttpActionResult> CreateCustomer()
        {
            var endpointAddress = new Uri(ConfigurationManager.AppSettings["XSolution_queue"]);

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

            return new AcceptedActionResult<string>(Request, "Success!");
        }
        [HttpGet]
        public async Task<IHttpActionResult> CreateOrder()
        {
            var endpointAddress = new Uri(ConfigurationManager.AppSettings["XSolution_queue"]);

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

            return new AcceptedActionResult<string>(Request, "Success!");

        }

        public ValuesController(IBus bus) : base(bus)
        {
        }
    }
}
