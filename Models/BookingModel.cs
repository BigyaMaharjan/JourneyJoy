using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JourneyJoy.Models
{
    public class BookingModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        public string DrivingLicence { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = "UID is required.")]
        public string UID { get; set; }

        public string VID { get; set; }

        [Required(ErrorMessage = "From Date is required.")]
        public string FromDate { get; set; }

        [Required(ErrorMessage = "To Date is required.")]
        public string ToDate { get; set; }

        [Required(ErrorMessage = "Vehicle Type is required.")]
        public string VehicleType { get; set; }

        [Required(ErrorMessage = "Current Address is required.")]
        public string CurrentAddress { get; set; }
    }
}