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

        public int Years { get; set; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        public Hand Hand { get; set; }

        public BackHand BackHand { get; set; }

        [Display(Name = "Prefered Surface")]
        public Surface PreferredSurface { get; set; }

        [Display(Name = "Play since (years)")]
        public int PlaySinceInYears { get; set; }

        [Display(Name = "Play frequency per week (hours)")]
        public int PlayFrequencyInHoursPerWeek { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.PhoneNumberMaxLenght)]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public Town Town { get; set; }
    }
}
