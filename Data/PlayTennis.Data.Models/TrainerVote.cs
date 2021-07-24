namespace PlayTennis.Data.Models
{
    using PlayTennis.Data.Common.Models;

    public class TrainerVote : BaseModel<int>
    {
        public int TrainerId { get; set; }

        public virtual Trainer Trainer { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public byte Value { get; set; }
    }
}
