namespace PlayTennis.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using PlayTennis.Data.Common.Repositories;
    using PlayTennis.Data.Models;

    public class ClubVoteService : IClubVoteService
    {
        private readonly IRepository<ClubVote> votesRepository;

        public ClubVoteService(IRepository<ClubVote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public double GetAverageVotes(int clubId)
        {
            var averageVotes = this.votesRepository.All()
                 .Where(x => x.ClubId == clubId)
                 .Average(x => x.Value);

            return averageVotes;
        }

        public async Task SetVoteAsync(int clubId, string userId, byte value)
        {
            var vote = this.votesRepository
                .All()
                .FirstOrDefault(x => x.ClubId == clubId && x.UserId == userId);

            if (vote == null)
            {
                vote = new ClubVote
                {
                    ClubId = clubId,
                    UserId = userId,
                };

                await this.votesRepository.AddAsync(vote);
            }

            vote.Value = value;
            await this.votesRepository.SaveChangesAsync();
        }
    }
}
