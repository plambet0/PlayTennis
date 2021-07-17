namespace PlayTennis.Services.Data
{
    using System.Threading.Tasks;

    using PlayTennis.Web.ViewModels.Player;

    public interface IPlayersService
    {
        Task CreateAsync(PlayerInputModel input, string userId);
    }
}
