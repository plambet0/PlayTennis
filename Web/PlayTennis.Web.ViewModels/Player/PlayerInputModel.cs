namespace PlayTennis.Web.ViewModels.Player
{
    using System.ComponentModel.DataAnnotations;

    using PlayTennis.Common;
    using PlayTennis.Data.Models;

    public class PlayerInputModel
    {
        [Required]
        [MaxLength(GlobalConstants.DataValidations.PlayerFirstNameMaxLenght)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.PlayerLastNameMaxLenght)]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        [Range(1, 100, ErrorMessage = "Invalid Age")]
        public int Years { get; set; }

        [Display(Name = "Image URL")]
        [Required(ErrorMessage = "Invalid Image Url")]
        public string ImageUrl { get; set; }

        public Hand Hand { get; set; }

        public BackHand BackHand { get; set; }

        [Display(Name = "Prefered Surface")]
        public Surface PreferredSurface { get; set; }

        [Display(Name = "Play since (years)")]
        [Range(1, 100, ErrorMessage = "Invalid Period")]
        public int PlaySinceInYears { get; set; }

        [Display(Name = "Play frequency per week (hours)")]
        [Range(1, 1000, ErrorMessage = "Invalid Data")]
        public int PlayFrequencyInHoursPerWeek { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.PhoneNumberMaxLenght)]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public Town Town { get; set; }
    }
}
