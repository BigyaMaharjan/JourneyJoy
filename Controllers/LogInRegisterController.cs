using JourneyJoy.Interface.LogIn;
using JourneyJoy.Models;
using JourneyJoy.Static;
using Microsoft.Ajax.Utilities;
using System;
using System.Web.Mvc;

namespace JourneyJoy.Controllers
{
    public class LogInRegisterController : Controller
    {
        ILogIn _loginBuss;
        public LogInRegisterController(ILogIn logIn)
        {
            _loginBuss = logIn;
        }
        // GET: LogInRegister
        [HttpGet]
        public ActionResult LogInRegister()
        {
            if (TempData.ContainsKey("renderredirectdata"))
            {
                // Retrieve data from TempData and store it in ViewData
                ViewData["renderdata"] = TempData["renderredirectdata"];
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(LogInModel model)
        {
            ModelState.Remove("LogInID");
            ModelState.Remove("LogInError");
            if (ModelState.IsValid)
            {
                var registernewusers = _loginBuss.RegisterNewUser(model);
                if (registernewusers.Code == ResponseCode.SUCCESS)
                {
                    ModelState.AddModelError("LogInError", "ok");
                }
                return RedirectToAction("LogInRegister", "LogInRegister");
            }
            else
            {
                ModelState.AddModelError("LogInError", "User Authentication Failed");
                return RedirectToAction("LogInRegister", "LogInRegister");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserLogin(LogInModel model)
        {
            ModelState.Remove("Firstname");
            ModelState.Remove("Lastname");
            ModelState.Remove("Lastname");
            ModelState.Remove("Mobilenumber");
            ModelState.Remove("Email");
            ModelState.Remove("confirmpassword");
            ModelState.Remove("LogInID");
            ModelState.Remove("LogInError");
            if (ModelState.IsValid)
            {
                var userCheck = LogInCheck(model);
                if (userCheck.Item3 == false)
                {
                    ModelState.AddModelError("LogInError", "User Authentication Failed");
                }
                return RedirectToAction(userCheck.Item1, userCheck.Item2);
                //return View("LogInRegister", "LogInRegister");
            }
            else
            {
                return View("LogInRegister", "LogInRegister");
            }
        }
        public Tuple<string, string, bool> LogInCheck(LogInModel model)
        {
            var dbloginResponse = _loginBuss.LogIn(model);
            try
            {
                if (dbloginResponse.Code == 0)
                {
                    var response = dbloginResponse.Data.MapObject<LogInResponseModel>();
                    Session["CustomerID"] = response.CustomerID;
                    Session["Username"] = response.Username;
                    Session["Email"] = response.Email;
                    Session["ProfileImage"] = response.ProfileImage;
                    Session["Title"] = response.Title;
                    Session["MobileNumber"] = response.MobileNumber;
                    Session["Country"] = response.Country;
                    Session["City"] = response.City;
                    Session["UserType"] = response.UserType;
                    Session["DriverLicenceNumber"] = response.DriverLicenceNumber;
                    return new Tuple<string, string, bool>("DashBoard", "User", true);
                }
                else
                {
                    return new Tuple<string, string, bool>("Login", "Home", false);
                }
            }
            catch (Exception)
            {
                return new Tuple<string, string, bool>("Login", "Home", false);
            }
        }

        public ActionResult LogOff()
        {
            Session["Username"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}