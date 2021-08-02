using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Services.Data
{
    public interface IClubVoteService
    {
        Task SetVoteAsync(int clubId, string userId, byte value);

        double GetAverageVotes(int clubId);
    }
}
