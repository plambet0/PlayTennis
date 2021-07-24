namespace PlayTennis.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using PlayTennis.Web.ViewModels.Club;

    public interface IClubsService
    {
        Task CreateAsync(ClubInputModel input, string userId);

        IEnumerable<ClubsViewModel> GetAll(int page, int itemsPerPage = 12);

        IEnumerable<ClubsViewModel> GetAllById(string userId);

        ClubsViewModel GetById(int id);

        Task AddToFavoritesAsync(int id, string userId);
    }
}
