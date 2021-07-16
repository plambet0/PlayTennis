namespace PlayTennis.Data.Models
{
    using System;

    using PlayTennis.Data.Common.Models;

    public class ClubImage : BaseDeletableModel<string>
    {
        public ClubImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int ClubId { get; set; }

        public virtual Club Club { get; set; }

        public string Extension { get; set; }

        public string RemoteImageUrl { get; set; }

        // public string UserId { get; set; }

        // public virtual ApplicationUser User { get; set; }
    }
}
