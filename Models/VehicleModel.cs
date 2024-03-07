using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JourneyJoy.Models
{
    public class VehicleModel : BaseModel
    {
        public string VehicleID { get; set; }
        public string VehicleType { get; set; } // Car, Bike, Zeep, SUV,Scooter
        public string VehicleMdl { get; set; } //Model as duke 250 / 360
        public string CarCapacity { get; set; }
        public string Rating { get; set; }
        public string TotalMilage { get; set; }
        public string TotalSeats { get; set; }
        public string TotalPrice { get; set; }
        public string Image { get; set; }
        public string Detail { get; set; }
        public string BookingStatus { get; set; }
        public string BID { get; set; }
    }

    public class VehicleTypeModel : UserDetails
    {
        public string UserID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
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

    public class UserDetails
    {
        [EmailAddress(ErrorMessage = "Required")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is invalid")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [MaxLength(10, ErrorMessage = "Mobile number should be 10 digit"), MinLength(10, ErrorMessage = "Mobile number should be 10 digit")]
        [RegularExpression(@"^((980)|(981)|(982)|(984)|(985)|(986)|(974)|(976)|(975)|(988)|(961)|(962)|(972))([0-9])+$", ErrorMessage = "Invalid mobile number")]
        public string Phonenumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only Alphabets allowed")]
        public string Country { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only Alphabets allowed")]
        public string City { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        public string DrivingLicence { get; set; }
    }
}