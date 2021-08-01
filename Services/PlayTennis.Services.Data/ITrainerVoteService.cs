using System.Threading.Tasks;

namespace PlayTennis.Services.Data
{
    public interface ITrainerVoteService
    {
        Task SetVoteAsync(int trainerId, string userId, byte value);

        double GetAverageVotes(int trainerId);
    }
}
