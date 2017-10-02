using System.Web.Http;
using MassTransit;

namespace WebApi.Controllers
{
    public class EnhancedApiController : ApiController
    {
        protected readonly IBus Bus;

        protected EnhancedApiController(IBus bus)
        {
            Bus = bus;
        }
        protected IHttpActionResult Accepted<T>(T value)
        {
            return new AcceptedActionResult<T>(Request, value);
        }
    }
}