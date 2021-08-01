using PlayTennis.Data.Common.Repositories;
using PlayTennis.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Services.Data
{
    public class TrainerVoteService : ITrainerVoteService
    {
        private readonly IRepository<TrainerVote> votesRepository;

        public TrainerVoteService(IRepository<TrainerVote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public double GetAverageVotes(int trainerId)
        {
            var averageVotes = this.votesRepository.All()
                 .Where(x => x.TrainerId == trainerId)
                 .Average(x => x.Value);

            return averageVotes;
        }

        public async Task SetVoteAsync(int trainerId, string userId, byte value)
        {
            var vote = this.votesRepository
                .All()
                .FirstOrDefault(x => x.TrainerId == trainerId && x.UserId == userId);

            if (vote == null)
            {
                vote = new TrainerVote
                {
                    TrainerId = trainerId,
                    UserId = userId,
                };

                await this.votesRepository.AddAsync(vote);
            }

            vote.Value = value;
            await this.votesRepository.SaveChangesAsync();
        }
    }
}
