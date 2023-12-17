using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JourneyJoy.Models
{
    public class VehicleModel
    {
        public string VehicleType { get; set; } // Car, Bike, Zeep, SUV,Scooter
        public string VehicleMdl { get; set; } //Model as duke 250 / 360
        public string CarCapacity { get; set; }
        public string Rating { get; set; }
        public string TotalSeats { get; set; }
        public string TotalMilage { get; set; }
        public string TotalPrice { get; set; }
        public string Image { get; set; }
        public string VehicleID { get; set; }
    }
}