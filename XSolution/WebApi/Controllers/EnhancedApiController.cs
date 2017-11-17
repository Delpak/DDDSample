using System.Web.Http;
using MassTransit;

namespace SAMA.XSolution.WebApi.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        protected readonly IBus Bus;

        protected BaseApiController(IBus bus)
        {
            Bus = bus;
        }
        protected IHttpActionResult Accepted<T>(T value)
        {
            return new AcceptedActionResult<T>(Request, value);
        }
    }
}