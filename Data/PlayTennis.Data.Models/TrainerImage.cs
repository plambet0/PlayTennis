namespace PlayTennis.Data.Models
{
    using System;

    using PlayTennis.Data.Common.Models;

    public class TrainerImage : BaseDeletableModel<string>
    {
        public TrainerImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int TrainerId { get; set; }

        public virtual Trainer Trainer { get; set; }

        public string Extension { get; set; }

        public string RemoteImageUrl { get; set; }

        // public string UserId { get; set; }

        // public virtual ApplicationUser User { get; set; }
    }
}
