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
        public int TotalSeats { get; set; }
        public float TotalMilage { get; set; }
        public decimal TotalPrice { get; set; }
    }
}