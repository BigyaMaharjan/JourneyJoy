using System.ComponentModel.DataAnnotations;

namespace JourneyJoy.Models
{
    public class RentSearchModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [Display(Name = "Going To")]
        public string FromLocation { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [Display(Name = "Arriving At")]
        public string ToLocation { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [Display(Name = "From Time")]
        public string FromTime { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [Display(Name = "To Time")]
        public string ToTime { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [Display(Name = "From Date")]
        public string FromDate { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [Display(Name = "To Date")]
        public string ToDate { get; set; }
        public string ErrorMessage { get; set; }
    }
}