using JourneyJoy.Interface.Booking;
using JourneyJoy.Models;
using System.IO;
using System.Linq;
using System;
using System.Web;
using System.Web.Mvc;
using JourneyJoy.Interface.LogIn;
using JourneyJoy.Static;

namespace JourneyJoy.Controllers
{
    public class UserController : Controller
    {
        IBooking _BookingBuss;
        ILogIn _loginBuss;

        public UserController(IBooking booking, ILogIn logIn)
        {
            _BookingBuss = booking;
            _loginBuss = logIn;
        }

        [HttpGet]
        public ActionResult DashBoard()
        {
            LogInResponseModel model = new LogInResponseModel();
            TempData["message"] = "LogInSuccess";
            try
            {
                var uid = Session["CustomerID"].ToString();
                if (!string.IsNullOrEmpty(uid))
                {
                    var userbookedvehicles = _BookingBuss.GetUserBookings(uid);
                    var dbres = _loginBuss.GetUserDetails(uid);
                    model = dbres.Data.MapObject<LogInResponseModel>();
                    if (TempData.ContainsKey("renderredirectdata"))
                    {
                        ViewData["renderdata"] = TempData["renderredirectdata"];
                    }
                    ViewBag.UserVehiclesLists = userbookedvehicles.Data;
                }
            }
            catch (Exception exe)
            {
                ViewData["renderdata"] = new { Icon = "false", Message = "Session time out, Please log in Again" };
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUserProfile(BookingModel model, HttpPostedFileBase file)
        {
            if (Session["CustomerID"] != null)
            {
                string FileLocationPath = "~/Content/Assets/UserUpload/";
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    file = Request.Files[i];
                }
                if (file != null && file.ContentLength > 0)
                {
                    var contentType = file.ContentType;
                    var allowedContenttype = new[] { "image/jpeg", "image/png", "image/jpg" };
                    var ext = Path.GetExtension(file.FileName);
                    string filepath;
                    if (allowedContenttype.Contains(contentType.ToLower()))
                    {
                        string datet = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                        string myfilename = "DrivingLicence" + datet + ext.ToLower();
                        filepath = Path.Combine(Server.MapPath(FileLocationPath), myfilename);
                        string fullFilePath = filepath;
                        string relativePath = fullFilePath.Replace(Server.MapPath("~/"), "~/").Replace("\\", "/");
                        model.Image = relativePath;
                        model.UID = Session["CustomerID"].ToString();
                    }
                    else
                    {
                        //this.ShowPopup(1, "File Must be .jpg,.png,.jpeg");
                        return Json(new { Code = "0" });
                    }
                    var dbresp = _loginBuss.UpdateUserProfile(model);
                    if (dbresp.Code == 0)
                    {
                        Static.StaticMethods.ResizeImage(file, filepath);
                        TempData["renderredirectdata"] = new { Icon = "true", Message = "User Profile Updated." };
                        return RedirectToAction("DashBoard", "User");
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
            return RedirectToAction("DashBoard");
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