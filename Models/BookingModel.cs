using System;
using System.Collections.Generic;
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
    }
}