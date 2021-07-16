namespace PlayTennis.Data.Models
{
    using System;

    using PlayTennis.Data.Common.Models;

    public class Reservation
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public int PlayerId { get; set; }

        public virtual Player Player { get; set; }

        public int ClubId { get; set; }

        public virtual Club Club { get; set; }
    }
}
