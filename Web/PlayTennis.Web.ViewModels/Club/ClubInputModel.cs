namespace PlayTennis.Web.ViewModels.Club
{

    using System.ComponentModel.DataAnnotations;

    using PlayTennis.Common;
    using PlayTennis.Data.Models;

    public class ClubInputModel
    {
        [Required]
        [MaxLength(GlobalConstants.DataValidations.ClubNameMaxLenght)]
        [Display(Name = "The Name of the Club")]
        public string Name { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.ClubAddressMaxLenght)]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Number of courts for play")]
        [Range(1, 30, ErrorMessage = "Invalid number")]
        public int Courts { get; set; }

        [Required(ErrorMessage = "Invalid Image Url")]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        [Range(1, 1000, ErrorMessage = "Invalid Price")]
        [Display(Name = "Price per hour (lv.)")]
        public decimal PricePerHour { get; set; }

        public Surface Surface { get; set; }

        public Town Town { get; set; }
    }
}
