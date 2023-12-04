using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JourneyJoy.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult BookVehicle()
        {
            return View();
        }
    }
}