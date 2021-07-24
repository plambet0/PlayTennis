namespace PlayTennis.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PlayTennis.Common;
    using PlayTennis.Data.Common.Models;

    public class Trainer : BaseModel<int>
    {
        public Trainer()
        {
            this.Votes = new HashSet<TrainerVote>();
        }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.TrainerFirstNameMaxLenght)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.TrainerLastNameMaxLenght)]
        public string LastName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public Gender Gender { get; set; }

        public int Years { get; set; }

        public int TrainerSinceInYears { get; set; }

        public decimal PricePerHour { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.PhoneNumberMaxLenght)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public virtual Town Town { get; set; }

        public virtual ICollection<TrainerVote> Votes { get; set; }
    }
}
