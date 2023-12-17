using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JourneyJoy.Models
{
    public class LogInModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [Display(Name = "Username")]
        public string LogInID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [Display(Name = "Password")]
        [MaxLength(16, ErrorMessage = "Maximum 16 characters allowed")]
        [MinLength(8, ErrorMessage = "Minimum 8 characters allowed")]
        public string password { get; set; }
        public string LogInError { get; set; }
    }

    public class LogInResponseModel
    {
        public string CustomerID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string ProfileImage { get; set; }
        public string Title { get; set; } //Miss,Mrs,Mr
        public string MobileNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Age { get; set; }
        public string DriverLicenceNumber { get; set; }
        public string UserType { get; set; }
    }
}