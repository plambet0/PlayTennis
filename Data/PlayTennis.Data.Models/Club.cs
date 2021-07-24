namespace PlayTennis.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PlayTennis.Common;
    using PlayTennis.Data.Common.Models;

    public class Club : BaseModel<int>
    {
        public Club()
        {
            this.Reservations = new HashSet<Reservation>();
            this.Votes = new HashSet<ClubVote>();
            this.PlayersClubs = new HashSet<PlayerClubs>();
        }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.ClubNameMaxLenght)]
        public string Name { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.ClubAddressMaxLenght)]
        public string Address { get; set; }

        public int Courts { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public decimal PricePerHour { get; set; }

        public Surface Surface { get; set; }

        public Town Town { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual ICollection<PlayerClubs> PlayersClubs { get; set; }

        public virtual ICollection<ClubVote> Votes { get; set; }
    }
}
