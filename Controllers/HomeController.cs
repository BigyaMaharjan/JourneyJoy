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
                    ViewData["renderdata"] = new { Icon = "true", Message = "User Contact info saved " + responseList.FirstName + " " + responseList.LastName };
                }
                else
                {
                    ViewData["renderdata"] = new { Icon = "false", Message = "Something went wrong, Plase try again" };
                }
            }
            else
            {
                ViewData["renderdata"] = new { Icon = "false", Message = "Contact Not Saved, Invalid Data Input" };
            }
            return View();
        }

        [HttpGet]
        public ActionResult Category()
        {
            return View();
        }
        #endregion

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