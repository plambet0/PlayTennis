namespace PlayTennis.Data.Models
{
    using PlayTennis.Data.Common.Models;

    public class PlayerClub
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public virtual Player Player { get; set; }

        public int ClubId { get; set; }

        public virtual Club Club { get; set; }
    }
}
