using JourneyJoy.Interface.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JourneyJoy.Controllers
{
    public class BookingController : Controller
    {
        IVehicle _VehicleBuss;
        public BookingController(IVehicle vehicle)
        {
            _VehicleBuss = vehicle;
        }
        // GET: Booking
        public ActionResult BookVehicle(string VID)
        {
            if (!string.IsNullOrEmpty(VID))
            {
                var resultVehicle = _VehicleBuss.GetVehicleById(VID);
                if (resultVehicle != null)
                {
                    return View(resultVehicle.Data);
                }
                return View();
            }
            return RedirectToAction("LogInRegister", "LogInRegister");
            //if (User.Identity.IsAuthenticated)
            //{
            //    if (!string.IsNullOrEmpty(VID))
            //    {
            //        return View();
            //    }
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("LogInRegister", "LogInRegister");
            //}
        }
    }
}