namespace PlayTennis.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PlayTennis.Data.Common.Models;

    public class Trainer : BaseModel<int>
    {
        public Trainer()
        {
            this.Clubs = new HashSet<TrainerClub>();
        }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        [MaxLength(10)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(10)]
        public string LastName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public Gender Gender { get; set; }

        public int Years { get; set; }

        public int TrainerSinceInYears { get; set; }

        public decimal PricePerHour { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public virtual Town Town { get; set; }

        public virtual ICollection<TrainerClub> Clubs { get; set; }
    }
}
