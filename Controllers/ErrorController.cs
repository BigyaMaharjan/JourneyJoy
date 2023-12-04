using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JourneyJoy.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult SomethingWentWrong()
        {
            return View();
        }

        public ActionResult NoPlaceFound()
        {
            return View();
        }

        public ActionResult NoVehicleFound()
        {
            return View();
        }
    }
}