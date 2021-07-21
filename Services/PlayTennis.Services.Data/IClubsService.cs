

using PlayTennis.Web.ViewModels.Club;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayTennis.Services.Data
{
    public interface IClubsService
    {
        Task CreateAsync(ClubInputModel input, string userId);

        IEnumerable<ClubsViewModel> GetAll(int page, int itemsPerPage = 12);

        ClubsViewModel GetById(int id);
    }
}
