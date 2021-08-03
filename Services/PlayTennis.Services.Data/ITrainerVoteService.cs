namespace PlayTennis.Services.Data
{
    using System.Threading.Tasks;

    public interface ITrainerVoteService
    {
        Task SetVoteAsync(int trainerId, string userId, byte value);

        double GetAverageVotes(int trainerId);
    }
}
