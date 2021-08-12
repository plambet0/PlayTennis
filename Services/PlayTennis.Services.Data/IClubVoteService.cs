namespace PlayTennis.Services.Data
{
    using System.Threading.Tasks;

    public interface IClubVoteService
    {
        Task SetVoteAsync(int clubId, string userId, byte value);

        double GetAverageVotes(int clubId);
    }
}
