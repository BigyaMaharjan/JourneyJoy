
using System.ComponentModel.DataAnnotations;

namespace JourneyJoy.Models
{
    public class CustomerModel
    {
        [Required(ErrorMessage = "Customer ID is required.")]
        public string CustomerID { get; set; }

        [Required(ErrorMessage = "Customer name is required.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        [Phone(ErrorMessage = "Invalid mobile number.")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [RegularExpression("^(Miss|Mrs|Mr)$", ErrorMessage = "Invalid title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Post code is required.")]
        public string PostCode { get; set; }

        public string Vehicle { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        public string Age { get; set; }

        public string Gender { get; set; }

        [Required(ErrorMessage = "Driver's license number is required.")]
        public int DriverLicenceNumber { get; set; }

        public string DriverLicenceImage { get; set; }

        [Required(ErrorMessage = "Refundable deposit is required.")]
        public double RefundableDeposite { get; set; }

        [Required(ErrorMessage = "Grand total is required.")]
        public double GrandTotal { get; set; }
    }
}