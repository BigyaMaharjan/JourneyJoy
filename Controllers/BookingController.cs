using JourneyJoy.Interface.Booking;
using JourneyJoy.Interface.Vehicle;
using JourneyJoy.Models;
using System.IO;
using System.Linq;
using System;
using System.Web;
using System.Web.Mvc;
using System.Drawing.Drawing2D;
using System.Drawing;
using Newtonsoft.Json;

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
                        model.Image = filepath + myfilename;
                        model.UID = Session["CustomerID"].ToString();
                    }
                    else
                    {
                        //this.ShowPopup(1, "File Must be .jpg,.png,.jpeg");
                        return Json(new { Code = "0" });
                    }
                    var dbresp = _BookingBuss.SaveBooking(model);
                    if (dbresp.Code == 0)
                    {
                        ResizeImage(file, filepath);
                        return RedirectToAction("DashBoard", "User");
                    }
                }
                else
                {
                    ViewData["renderdata"] = new
                    {
                        Icon = "false",
                        Message = "Image File is Required"
                    };
                }
            }
            else
            {
                ViewBag.SomeData = "Hello from controller!";
                //ViewBag.renderdata = new
                //{
                //    Icon = "false",
                //    Message = "Please login before booking"
                //};
                //ViewData["renderdata"] = new
                //{
                //    Icon = "false",
                //    Message = "Please login before booking"
                //};
                //ViewBag.renderdata = JsonConvert.SerializeObject(new
                //{
                //    Icon = "false",
                //    Message = "Please login before booking"
                //});
                return RedirectToAction("LogInRegister", "LogInRegister");
            }
            return RedirectToAction("BookVehicle");
        }

        public void ResizeImage(HttpPostedFileBase file, string toStream)//double scaleFactor,
        {
            if (file.ContentLength > 1 * 1024 * 1024)//1 MB
            {
                var image = Image.FromStream(file.InputStream);
                var newWidth = (int)(600);
                var newHeight = (int)(600);
                var thumbnailBitmap = new Bitmap(newWidth, newHeight);

                var thumbnailGraph = Graphics.FromImage(thumbnailBitmap);
                thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;

                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbnailGraph.DrawImage(image, imageRectangle);

                thumbnailBitmap.Save(toStream, image.RawFormat);//image.RawFormat

                thumbnailGraph.Dispose();
                thumbnailBitmap.Dispose();
                image.Dispose();
            }
            else
            {
                file.SaveAs(toStream);
            }
        }
    }
}