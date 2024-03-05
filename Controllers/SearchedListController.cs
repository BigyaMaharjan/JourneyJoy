using JourneyJoy.Interface.Vehicle;
using System.Web.Mvc;

namespace JourneyJoy.Controllers
{
    public class SearchedListController : Controller
    {
        IVehicle _VehicleBuss;
        public SearchedListController(IVehicle vehicle)
        {
            _VehicleBuss = vehicle;
        }

        [HttpGet]
        // GET: SearchedList
        public ActionResult VehicleList(string type)
        {
            if (!string.IsNullOrEmpty(type))
            {
                var selectedTypeList = _VehicleBuss.GetVehicleByType(type);
                if (selectedTypeList != null)
                {
                    ViewBag.VehicleType = type;
                    return View(selectedTypeList.Data);
                }
            }
            return View();
        }
    }
}