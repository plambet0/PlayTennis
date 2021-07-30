namespace PlayTennis.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PlayTennis.Web.ViewModels.Club;
    using PlayTennis.Web.ViewModels.Player;

    public interface IPlayersService
    {
        Task CreateAsync(PlayerInputModel input, string userId);

        IEnumerable<PlayersViewModel> GetAll(int page, int itemsPerPage = 12);

        bool IsATrainer(string userId);

        bool IsRegistered(string userId);

        PlayersViewModel GetById(string userId);

        Task AddToFavoritesAsync(int clubId, string userId);

        IEnumerable<ClubsViewModel> GetAllFavorites( string userId, int page, int itemsPerPage = 12);

        Task DeleteFromFavoritesAsync(int clubId, string userId);
    }
}
