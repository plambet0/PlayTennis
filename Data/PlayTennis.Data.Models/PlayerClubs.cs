

namespace PlayTennis.Data.Models
{
    public class PlayerClubs
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public Player Player { get; set; }

        public int ClubId { get; set; }

        public Club Club { get; set; }
    }
}
