

namespace PlayTennis.Data.Models
{
    public class UserClub
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int ClubId { get; set; }

        public virtual Club Club { get; set; }
    }
}
