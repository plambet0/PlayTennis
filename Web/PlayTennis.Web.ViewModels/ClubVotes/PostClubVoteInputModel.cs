namespace PlayTennis.Web.ViewModels.ClubVotes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PostClubVoteInputModel
    {
        public int ClubId { get; set; }

        [Range(1, 5)]
        public byte Value { get; set; }
    }
}
