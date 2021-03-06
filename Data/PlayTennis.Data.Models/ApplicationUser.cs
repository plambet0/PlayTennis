// ReSharper disable VirtualMemberCallInConstructor
namespace PlayTennis.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;
    using PlayTennis.Data.Common.Models;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.FavoriteClubs = new HashSet<UserClub>();
            this.ClubVotes = new HashSet<ClubVote>();
            this.TrainerVotes = new HashSet<TrainerVote>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<UserClub> FavoriteClubs { get; set; }

        public virtual ICollection<TrainerVote> TrainerVotes { get; set; }

        public virtual ICollection<ClubVote> ClubVotes { get; set; }
    }
}
