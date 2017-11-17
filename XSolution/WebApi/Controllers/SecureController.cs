using System.Net;
using System.Net.Http;
using System.Security.Claims;
using MassTransit;
using SAMA.XSolution.WebApi.Filters;

namespace SAMA.XSolution.WebApi.Controllers
{
    [HmacAuthentication]
    public class SecureController : BaseApiController
    {
        public HttpResponseMessage Get()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;

            var Name = ClaimsPrincipal.Current.Identity.Name;

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public SecureController(IBus bus) : base(bus)
        {
        }
    }
}