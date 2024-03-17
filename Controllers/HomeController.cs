using JourneyJoy.Interface.LogIn;
using JourneyJoy.Interface.Vehicle;
using JourneyJoy.Models;
using JourneyJoy.Static;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace JourneyJoy.Controllers
{
    public class HomeController : Controller
    {
        ILogIn _loginBuss;
        IVehicle _VehicleBuss;

        public HomeController(ILogIn login, IVehicle vehicle)
        {
            _loginBuss = login;
            _VehicleBuss = vehicle;
        }

        #region Landing Page
        [HttpGet]
        public ActionResult Index()
        {
            List<VehicleModel> recVehicle = new List<VehicleModel>();
            var GetCVehicle = _VehicleBuss.GetRecentlyAddedVehicleList();
            var locationlist = _VehicleBuss.GetLocationList();
            ViewBag.LocationList = StaticMethods.CreateDropdownList(locationlist);
            if (GetCVehicle != null)
            {
                if (GetCVehicle.Code == ResponseCode.SUCCESS)
                {
                    recVehicle = GetCVehicle.Data.MapObjects<VehicleModel>();
                    return View(recVehicle);
                }
                else
                {
                    return View();
                }
            }
            return View();
        }

        #region Contact Us
        [HttpGet]
        public ActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                var contactDetails = _loginBuss.SaveContactInformation(model);
                if (contactDetails.Code == ResponseCode.SUCCESS)
                {
                    LogInResponseModel responseList = contactDetails.Data.MapObject<LogInResponseModel>();
                    TempData["renderredirectdata"] = new { Icon = "true", Message = "User Contact info saved " + responseList.FirstName + " " + responseList.LastName };
                }
                else
                {
                    TempData["renderredirectdata"] = new { Icon = "false", Message = "Something went wrong, Plase try again" };
                }
            }
            else
            {
                TempData["renderredirectdata"] = new { Icon = "false", Message = "Contact Not Saved, Invalid Data Input" };
            }
            return View();
        }

        [HttpGet]
        public ActionResult Category()
        {
            return View();
        }
        #endregion
        [HttpPost]
        public ActionResult Index(RentSearchModel model)
        {
            if (ModelState.IsValid)
            {
                var SearchedVehicleList = _VehicleBuss.GetVehicleList(model);
                if (SearchedVehicleList.Code == ResponseCode.SUCCESS)
                {
                    List<VehicleModel> responseList = SearchedVehicleList.Data.MapObjects<VehicleModel>();
                    TempData["ResponseList"] = responseList;
                    return RedirectToAction("VehicleList", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("SearchError", "Some Input fields are Missing");
                TempData["message"] = "Added";

                string errorMessage = "Action failed changed....";
                ViewBag.ErrorMessage = errorMessage;

                ModelState.AddModelError("SearchError", "Some Input fields are Missing");
                //OR ADD thorugh Model 
                //model.ErrorMessage = "Some Input fields are Missing";
            }
            return View();
        }
        #endregion

        #region LogIn/ LogOut | Register
        [HttpPost]
        public ActionResult Register(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                ModelState.AddModelError("LogInError", "User Authentication Failed");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Login(LogInModel model)
        {
            ModelState.Remove("Firstname");
            ModelState.Remove("Lastname");
            ModelState.Remove("Lastname");
            ModelState.Remove("Mobilenumber");
            ModelState.Remove("Email");
            ModelState.Remove("confirmpassword");
            if (ModelState.IsValid)
            {
                var userCheck = LogInCheck(model);
                if (userCheck.Item3 == false)
                {
                    ModelState.AddModelError("LogInError", "User Authentication Failed");
                }
                return RedirectToAction(userCheck.Item1, userCheck.Item2);
            }
            else
            {
                ModelState.AddModelError("LogInError", "User Authentication Failed");
                return View();
            }
        }

        public Tuple<string, string, bool> LogInCheck(LogInModel model)
        {
            var dbloginResponse = _loginBuss.LogIn(model);
            try
            {
                if (dbloginResponse.Code == 0)
                {
                    //var response = dbloginResponse.Data.MapObject<LogInResponseModel>();
                    //Session["CustomerID"] = response.CustomerID;
                    //Session["Username"] = response.Username;
                    //Session["Email"] = response.Email;
                    //Session["ProfileImage"] = response.ProfileImage;
                    //Session["Title"] = response.Title;
                    //Session["MobileNumber"] = response.MobileNumber;
                    //Session["Country"] = response.Country;
                    //Session["City"] = response.City;
                    //Session["PostCode"] = response.PostCode;
                    //Session["UserType"] = response.UserType;
                    //Session["DriverLicenceNumber"] = response.DriverLicenceNumber;
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

        #endregion

        #region DashBoard About Section
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }
        #endregion

        #region Vehicle Search 
        [HttpPost]
        public ActionResult VehicleList(RentSearchModel model)
        {
            var Vehicle = _VehicleBuss.GetVehicleList(model);
            ViewBag.VehicleType = model.VehicleCategory;
            List<VehicleModel> responseList = Vehicle.Data.MapObjects<VehicleModel>();
            return View(responseList);
        }
        #endregion
    }
}