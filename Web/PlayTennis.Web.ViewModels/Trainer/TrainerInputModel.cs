namespace PlayTennis.Web.ViewModels.Trainer
{
    using System.ComponentModel.DataAnnotations;

    using PlayTennis.Common;
    using PlayTennis.Data.Models;

    public class TrainerInputModel
    {
        [Required]
        [MaxLength(GlobalConstants.DataValidations.TrainerFirstNameMaxLenght)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.TrainerLastNameMaxLenght)]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        [Range(1, 100, ErrorMessage = "Invalid Age")]
        public int Years { get; set; }

        [Display(Name = "Image URL")]
        [Required(ErrorMessage = "Invalid Image Url")]
        public string ImageUrl { get; set; }

        [Display(Name = "Trainer Since")]
        [Range(1, 100)]
        public int TrainerSinceInYears { get; set; }

        [Range(1, 1000, ErrorMessage = "Ivalid Price")]
        public decimal PricePerHour { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.PhoneNumberMaxLenght)]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        public virtual Town Town { get; set; }
    }
}
