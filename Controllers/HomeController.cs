using JourneyJoy.Interface.LogIn;
using JourneyJoy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JourneyJoy.Controllers
{
    public class HomeController : Controller
    {
        ILogIn _loginBuss;
        public HomeController(ILogIn login)
        {
            _loginBuss = login;
        }
        [HttpGet]
        public ActionResult Index()
        {
            //return RedirectToAction("BookVehicle", "Booking");
            return View();
        }

        [HttpPost]
        public ActionResult Index(TestModel model)
        {

            //return RedirectToAction("BookVehicle", "Booking");
            return View();
        }
                

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Login(CustomerModel model)
        {
            var error  = new CommonModel();
            var myLogIn = _loginBuss.LogIn(model);
            if (myLogIn == null)
            {
                ViewBag.Message = error.Code;
            }
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult VehicleList()
        {
            return View();
        }
    }
}