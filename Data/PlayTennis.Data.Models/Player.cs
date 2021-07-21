namespace PlayTennis.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using PlayTennis.Data.Common.Models;

    public class Player : BaseModel<int>
    {
        public Player()
        {
            this.FavoriteClubs = new HashSet<PlayerClub>();
            this.Reservations = new HashSet<Reservation>();
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

        public Hand Hand { get; set; }

        public BackHand BackHand { get; set; }

        public Surface PreferredSurface { get; set; }

        public int PlaySinceInYears { get; set; }

        public int PlayFrequencyInHoursPerWeek { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public virtual Town Town { get; set; }

        public virtual ICollection<PlayerClub> FavoriteClubs { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
