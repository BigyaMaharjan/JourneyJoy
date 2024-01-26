using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JourneyJoy.Controllers
{
    public class SearchedListController : Controller
    {
        [HttpGet]
        // GET: SearchedList
        public ActionResult VehicleList()
        {
            return View();
        }
    }
}