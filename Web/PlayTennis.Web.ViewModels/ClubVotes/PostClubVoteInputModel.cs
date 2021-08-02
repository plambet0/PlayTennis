using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlayTennis.Web.ViewModels.ClubVotes
{
    public class PostClubVoteInputModel
    {
        public int ClubId { get; set; }

        [Range(1, 5)]
        public byte Value { get; set; }
    }
}
