namespace PlayTennis.Data.Models
{
    using System;

    public class Reservation
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int ClubId { get; set; }

        public virtual Club Club { get; set; }
    }
}
