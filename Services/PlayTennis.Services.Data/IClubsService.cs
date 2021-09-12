namespace PlayTennis.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using PlayTennis.Web.ViewModels.Club;

    public interface IClubsService
    {
        Task CreateAsync(ClubInputModel input, string userId);

        IEnumerable<ClubsViewModel> GetAll(int page, int itemsPerPage = 12);

        ClubDetailsViewModel GetById(int id);

        EditClubInputModel EditById(int id);

        Task DeleteAsync(int id);

        Task UpdateAsync(int id, EditClubInputModel input);

        int GetCount();

        IEnumerable<ClubsViewModel> GetAllByTown(string town);
    }
}
