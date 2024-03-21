using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JourneyJoy.Models
{
    public class BookingModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string DrivingLicence { get; set; }
        public string Image { get; set; }
        public string UID { get; set; }
        public string VID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string VehicleType { get; set; }
        public string CurrentAddress { get; set; }
    }
}