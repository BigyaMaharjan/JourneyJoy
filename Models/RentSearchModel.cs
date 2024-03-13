using System.ComponentModel.DataAnnotations;

namespace JourneyJoy.Models
{
    public class RentSearchModel
    {        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        public string location { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        public string VehicleCategory { get; set; }
        public string ErrorMessage { get; set; }
    }
}