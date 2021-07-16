namespace PlayTennis.Data.Models
{
    using System;
    using System.Collections.Generic;

    using PlayTennis.Data.Common.Models;

    public class Trainer : BaseModel<int>
    {
        public Trainer()
        {
            this.Clubs = new HashSet<TrainerClub>();
            this.Images = new HashSet<TrainerImage>();
        }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime Birthdate { get; set; }

        public string Years { get; set; }

        public DateTime TrainerSince { get; set; }

        public decimal PricePerHour { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public virtual Town Town { get; set; }

        public virtual ICollection<TrainerClub> Clubs { get; set; }

        public virtual ICollection<TrainerImage> Images { get; set; }
    }
}
