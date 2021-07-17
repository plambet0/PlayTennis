namespace PlayTennis.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using PlayTennis.Web.ViewModels.Player;

    public interface IPlayersService
    {
        Task CreateAsync(PlayerInputModel input, string userId);

        IEnumerable<PlayersViewModel> GetAll(int page, int itemsPerPage = 12);
    }
}
