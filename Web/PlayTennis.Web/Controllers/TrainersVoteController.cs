using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayTennis.Services.Data;
using PlayTennis.Web.ViewModels.TrainerVotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PlayTennis.Web.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]

    public class TrainersVoteController : BaseController
    {
        private readonly ITrainerVoteService trainerVoteService;

        public TrainersVoteController(ITrainerVoteService trainerVoteService)
        {
            this.trainerVoteService = trainerVoteService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PostTrainerVoteResponseModel>> Post(PostTrainerVoteInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.trainerVoteService.SetVoteAsync(input.TrainerId, userId, input.Value);
            var averageVotes = this.trainerVoteService.GetAverageVotes(input.TrainerId);
            return new PostTrainerVoteResponseModel { AverageVote = averageVotes };
        }
    }
}
