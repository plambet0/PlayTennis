using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayTennis.Services.Data;
using PlayTennis.Web.ViewModels.ClubVotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PlayTennis.Web.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]

    public class ClubsVoteController : BaseController
    {
        private readonly IClubVoteService clubVoteService;

        public ClubsVoteController(IClubVoteService clubVoteService)
        {
            this.clubVoteService = clubVoteService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PostClubVoteResponseModel>> Post(PostClubVoteInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.clubVoteService.SetVoteAsync(input.ClubId, userId, input.Value);
            var averageVotes = this.clubVoteService.GetAverageVotes(input.ClubId);
            return new PostClubVoteResponseModel { AverageVote = averageVotes };
        }
    }
}
