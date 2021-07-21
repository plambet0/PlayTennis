namespace PlayTennis.Web.ViewModels.Trainer
{
    using System;
    using System.ComponentModel.DataAnnotations;
    

    using PlayTennis.Data.Models;

    public class TrainerInputModel
    {
        [Required]
        [MaxLength(10)]
        public string FirstName { get; set; }

        [Required]

        [MaxLength(10)]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        [Range(1, 100)]
        public int Years { get; set; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        [Display(Name = "Trainer Since")]
        public int TrainerSinceInYears { get; set; }

        public decimal PricePerHour { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public virtual Town Town { get; set; }
    }
}
