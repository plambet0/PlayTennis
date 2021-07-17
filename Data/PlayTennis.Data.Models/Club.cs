namespace PlayTennis.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using PlayTennis.Data.Common.Models;

    public class Club : BaseModel<int>
    {
        public Club()
        {
            this.Players = new HashSet<PlayerClub>();
            this.Trainers = new HashSet<TrainerClub>();
            this.Reservations = new HashSet<Reservation>();
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public int Courts { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public decimal PricePerHour { get; set; }

        public Surface Surface { get; set; }

        public Town Town { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<TrainerClub> Trainers { get; set; }

        public virtual ICollection<PlayerClub> Players { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
