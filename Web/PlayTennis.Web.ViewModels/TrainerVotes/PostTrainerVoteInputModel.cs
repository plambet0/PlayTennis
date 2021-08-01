using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlayTennis.Web.ViewModels.TrainerVotes
{
    public class PostTrainerVoteInputModel
    {
        public int TrainerId { get; set; }

        [Range(1, 5)]
        public byte Value { get; set; }
    }
}
