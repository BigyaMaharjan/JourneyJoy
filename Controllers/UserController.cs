using JourneyJoy.Interface.Booking;
using JourneyJoy.Models;
using System.Web.Mvc;

namespace JourneyJoy.Controllers
{
    public class UserController : Controller
    {
        IBooking _BookingBuss;

        public UserController(IBooking booking)
        {
            _BookingBuss = booking;
        }

        [HttpGet]
        public ActionResult DashBoard()
        {
            LogInResponseModel model = new LogInResponseModel();
            TempData["message"] = "LogInSuccess";
            var uid = Session["CustomerID"].ToString();
            if (!string.IsNullOrEmpty(uid))
            {
                var userbookedvehicles = _BookingBuss.GetUserBookings(uid);
                ViewBag.UserVehiclesLists = userbookedvehicles.Data;
            }
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