using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        //public async Task<ActionResult> Put(string value)
        //{
        //    await WebApiApplication.Bus.Publish<ISubmitValue>(new
        //    {
        //        Value = value
        //    });

        //    return View("Index");
        //}

        //public async Task<ActionResult> Send(string value)
        //{
        //    var endpoint = await WebApiApplication.Bus.GetSendEndpoint(new Uri("http://test.com"));

        //    await endpoint.Send<IValueNotified>(new
        //    {
        //        Timestamp = DateTime.UtcNow,
        //        Value = value
        //    });

        //    return View("Index");
        //}
    }
}
