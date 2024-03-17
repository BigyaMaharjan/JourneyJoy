using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JourneyJoy.Models
{
    public class LogInModel : RegisterModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [Display(Name = "Username")]
        public string LogInID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        public string LogInError { get; set; }
    }

    public class LogInResponseModel : BaseModel
    {
        public string CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Vehicle { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
        public string Title { get; set; } //Miss,Mrs,Mr
        public string UserType { get; set; } // Hidden (Customer/Merchant/Admin)
        public string ProfileImage { get; set; }
        public string Bio { get; set; }
        public string DriverLicenceNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string CurrentAddress { get; set; }
    }

    public class RegisterModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only Alphabets allowed")]
        public string Firstname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only Alphabets allowed")]
        public string Lastname { get; set; }
        [Display(Name = "Mobile Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [MaxLength(10, ErrorMessage = "Mobile number should be 10 digit"), MinLength(10, ErrorMessage = "Mobile number should be 10 digit")]
        [RegularExpression(@"^((980)|(981)|(982)|(984)|(985)|(986)|(974)|(976)|(975)|(988)|(961)|(962)|(972))([0-9])+$", ErrorMessage = "Invalid mobile number")]
        public string Mobilenumber { get; set; }
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Required")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is invalid")]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [MaxLength(16, ErrorMessage = "Maximum 16 characters allowed")]
        [MinLength(8, ErrorMessage = "Minimum 8 characters allowed")]
        public string password { get; set; }
        [Display(Name = "Confirm Password")]
        [MaxLength(16, ErrorMessage = "Maximum 16 characters allowed")]
        [MinLength(8, ErrorMessage = "Minimum 8 characters allowed")]
        public string confirmpassword { get; set; }
    }
}