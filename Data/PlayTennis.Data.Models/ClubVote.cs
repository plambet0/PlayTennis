namespace PlayTennis.Data.Models
{
    using PlayTennis.Data.Common.Models;

    public class ClubVote : BaseModel<int>
    {
        public int ClubId { get; set; }

        public virtual Club Club { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public byte Value { get; set; }
    }
}
