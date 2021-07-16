namespace PlayTennis.Data.Models
{
    using PlayTennis.Data.Common.Models;

    public class TrainerClub
    {
        public int Id { get; set; }

        public int TrainerId { get; set; }

        public virtual Trainer Trainer { get; set; }

        public int ClubId { get; set; }

        public virtual Club Club { get; set; }
    }
}
