
namespace JourneyJoy.Models
{
    public class CustomerModel
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Title { get; set; } //Miss,Mrs,Mr
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Vehicle { get; set; }
        public string Description { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public int DriverLicenceNumber { get; set; }
        public string DriverLicenceImage { get; set; }
        public double RefundableDeposite { get; set; }
        public double GrandTotal { get; set; }
        public string Vehicle { get; set; }
    }
}