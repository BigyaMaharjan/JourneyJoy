using JourneyJoy.Database;
using JourneyJoy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            LogInResponseModel model = new LogInResponseModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateUserProfile(LogInResponseModel model)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("DashBoard");
            }
            else
            {

                return View(model);
            }
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