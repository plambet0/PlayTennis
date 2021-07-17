﻿namespace PlayTennis.Data.Models
{
    using System;
    using System.Collections.Generic;

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

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        public Gender Gender { get; set; }

        public DateTime Birthdate { get; set; }

        public int Years { get; set; }

        public Hand Hand { get; set; }

        public BackHand BackHand { get; set; }

        public Surface PreferredSurface { get; set; }

        public DateTime PlaySince { get; set; }

        public int PlayFrequencyInHoursPerWeek { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public virtual Town Town { get; set; }

        public virtual ICollection<PlayerClub> FavoriteClubs { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
