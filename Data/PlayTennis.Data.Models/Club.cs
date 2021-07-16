namespace PlayTennis.Data.Models
{
    using System.Collections.Generic;

    using PlayTennis.Data.Common.Models;

    public class Club : BaseModel<int>
    {
        public Club()
        {
            this.Players = new HashSet<PlayerClub>();
            this.Trainers = new HashSet<TrainerClub>();
            this.Images = new HashSet<ClubImage>();
            this.Reservations = new HashSet<Reservation>();
        }

        public string Name { get; set; }

        public string Address { get; set; }

        public int Courts { get; set; }

        public decimal PricePerHour { get; set; }

        public Surface Surface { get; set; }

        public Town Town { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<ClubImage> Images { get; set; }

        public virtual ICollection<TrainerClub> Trainers { get; set; }

        public virtual ICollection<PlayerClub> Players { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
