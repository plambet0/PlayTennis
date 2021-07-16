namespace PlayTennis.Data.Models
{
    using System;

    using PlayTennis.Data.Common.Models;

    public class PlayerImage : BaseDeletableModel<string>
    {
        public PlayerImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int PlayerId { get; set; }

        public virtual Player Player { get; set; }

        public string Extension { get; set; }

        public string RemoteImageUrl { get; set; }

        // public string UserId { get; set; }

        // public virtual ApplicationUser User { get; set; }
    }
}
