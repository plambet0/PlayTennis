namespace PlayTennis.Web.ViewModels.Trainer
{
    using System;
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

        public int Years { get; set; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        [Display(Name = "Trainer Since")]
        public int TrainerSinceInYears { get; set; }

        public decimal PricePerHour { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.PhoneNumberMaxLenght)]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public virtual Town Town { get; set; }
    }
}
