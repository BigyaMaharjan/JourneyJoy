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

    public class LogInResponseModel : VehicleModel
    {
        [Required(ErrorMessage = "Customer ID is required.")]
        public string CustomerID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        public string Vehicle { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        public string Gender { get; set; }

        [RegularExpression("^(Miss|Mrs|Mr)$", ErrorMessage = "Invalid title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "User type is required.")]
        public string UserType { get; set; }
       
        [Url(ErrorMessage = "Invalid URL.")]
        public string ProfileImage { get; set; }

        public string Bio { get; set; }

        public string DrivingLicence { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string CurrentAddress { get; set; }

        public string UID { get; set; }
    }

    public class RegisterModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only Alphabets allowed")]
        public string Firstname { get; set; }
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
        public string UserType { get; set; }
    }
}