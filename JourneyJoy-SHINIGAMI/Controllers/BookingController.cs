using JourneyJoy.Interface.Booking;
using JourneyJoy.Interface.Vehicle;
using JourneyJoy.Models;
using System.IO;
using System.Linq;
using System;
using System.Web;
using System.Web.Mvc;

namespace JourneyJoy.Controllers
{
    public class BookingController : Controller
    {
        IVehicle _VehicleBuss;
        IBooking _BookingBuss;

        public BookingController(IVehicle vehicle, IBooking booking)
        {
            _VehicleBuss = vehicle;
            _BookingBuss = booking;
        }

        public ActionResult BookVehicle(string VID)
        {
            if (!string.IsNullOrEmpty(VID))
            {
                var resultVehicle = _VehicleBuss.GetVehicleById(VID);
                if (resultVehicle != null)
                {
                    if (TempData.ContainsKey("renderredirectdata"))
                    {
                        ViewData["renderdata"] = TempData["renderredirectdata"];
                    }
                    return View(resultVehicle.Data);
                }
                return View();
            }
            return RedirectToAction("LogInRegister", "LogInRegister");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmBooking(BookingModel model, HttpPostedFileBase file)
        {
            if (Session["CustomerID"] != null)
            {
                string FileLocationPath = "/Content/Assets/UserUpload/";
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    file = Request.Files[i];
                }
                if ((file != null && file.ContentLength > 0) || !string.IsNullOrEmpty(model.Image))
                {
                    string filepath;
                    model.UID = Session["CustomerID"].ToString();
                    if (file != null && file.ContentLength > 0)
                    {
                        var contentType = file.ContentType;
                        var allowedContenttype = new[] { "image/jpeg", "image/png", "image/jpg" };
                        var ext = Path.GetExtension(file.FileName);
                        if (allowedContenttype.Contains(contentType.ToLower()))
                        {
                            string datet = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                            string myfilename = "DrivingLicence" + datet + ext.ToLower();
                            filepath = Path.Combine(Server.MapPath(FileLocationPath), myfilename);
                            model.Image = filepath + myfilename;
                        }
                        else
                        {
                            //this.ShowPopup(1, "File Must be .jpg,.png,.jpeg");
                            return Json(new { Code = "0" });
                        }
                        var dbresp1 = _BookingBuss.SaveBooking(model);
                        if (dbresp1.Code == 0)
                        {
                            Static.StaticMethods.ResizeImage(file, filepath);
                            TempData["renderredirectdata"] = new { Icon = "true", Message = "Booking Successfull." };
                            return RedirectToAction("DashBoard", "User");
                        }
                    }
                    else
                    {
                        var dbresp = _BookingBuss.SaveBooking(model);
                        if (dbresp.Code == 0)
                        {
                            TempData["renderredirectdata"] = new { Icon = "true", Message = "Booking Successfull." };
                            return RedirectToAction("DashBoard", "User");
                        }
                        else
                        {
                            TempData["renderredirectdata"] = new { Icon = "false", Message = dbresp.Message };
                            return RedirectToAction("DashBoard", "User");
                        }
                    }
                }
                else
                {
                    TempData["renderredirectdata"] = new { Icon = "false", Message = "Image File is Required" };
                    return RedirectToAction("BookVehicle", new { VID = model.VID });
                }
            }
            else
            {
                TempData["renderredirectdata"] = new { Icon = "false", Message = "Please login before booking" };
                return RedirectToAction("LogInRegister", "LogInRegister");
            }
            return RedirectToAction("BookVehicle");
        }

        public ActionResult CancellBooking(string BID, string VID)
        {
            if (!string.IsNullOrEmpty(BID) && !string.IsNullOrEmpty(VID))
            {
                var dbresp = _BookingBuss.CancellBooking(BID, VID);
                if (dbresp.Code == 0)
                {
                    TempData["renderredirectdata"] = new { Icon = "true", Message = dbresp.Message };
                    return RedirectToAction("DashBoard", "User");
                }
                TempData["renderredirectdata"] = new { Icon = "false", Message = "Something went wrong!" };
                return RedirectToAction("DashBoard", "User");
            }
            else
            {
                TempData["renderredirectdata"] = new { Icon = "false", Message = "Couldn't process your request" };
                return RedirectToAction("DashBoard", "User");
            }
        }

        #region Vendor Add Vehicles
        public ActionResult AddVehicles(LogInResponseModel model)
        {
            if (ModelState.IsValid)
            {
                var dbresp = _BookingBuss.AddNewVehicles(model);
                if (dbresp.Code == ResponseCode.SUCCESS)
                {
                    TempData["renderredirectdata"] = new { Icon = "true", Message = "Successfully Added Vehicle." };
                }
                else
                {
                    TempData["renderredirectdata"] = new { Icon = "false", Message = "Something went wrong." };
                }
            }
            else
            {
                TempData["renderredirectdata"] = new { Icon = "false", Message = "Invalid Vehicle Data provided" };
            }
            return RedirectToAction("DashBoard", "User");
        }
        #endregion
    }
}