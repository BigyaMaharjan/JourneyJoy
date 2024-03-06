using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JourneyJoy.Models
{
    public class VehicleModel : BaseModel
    {
        public string VehicleType { get; set; } // Car, Bike, Zeep, SUV,Scooter
        public string VehicleMdl { get; set; } //Model as duke 250 / 360
        public string CarCapacity { get; set; }
        public string Rating { get; set; }
        public string TotalMilage { get; set; }
        public string TotalSeats { get; set; }
        public string TotalPrice { get; set; }
        public string Image { get; set; }
        public string VehicleID { get; set; }
        public string Detail { get; set; }
    }

    public class VehicleTypeModel
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string VehicleID { get; set; }
        public string VehicleType { get; set; }
        public string VehicleModel { get; set; }
        public string Title { get; set; }
        public string VehicleCapacity { get; set; }
        public string Rating { get; set; }
        public string TotalSeats { get; set; }
        public string IsAvailable { get; set; }
        public string TotalMilage { get; set; }
        public string ProfileImage { get; set; }
        public string TotalPrice { get; set; }
        public string Detail { get; set; }
    }
}