using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JourneyJoy.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult DashBoard()
        {
            TempData["message"] = "LogInSuccess";
            return View();
        }
        [HttpGet]
        public ActionResult GetOrderList()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UserProfile()
        {
            return View();
        }
    }
}