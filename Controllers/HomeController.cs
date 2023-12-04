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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

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
    }
}