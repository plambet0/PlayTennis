namespace PlayTennis.Services.Data
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using PlayTennis.Data.Common.Repositories;
    using PlayTennis.Data.Models;
    using PlayTennis.Web.ViewModels.Player;

    public class PlayersService : IPlayersService
    {
        private readonly IRepository<Player> playersRepository;

        public PlayersService(IRepository<Player> playersRepository)
        {
            this.playersRepository = playersRepository;
        }

        public async Task CreateAsync(PlayerInputModel input, string userId)
        {
            var player = new Player
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Gender = input.Gender,
                Town = input.Town,
                BackHand = input.BackHand,
                Hand = input.Hand,
                Birthdate = input.Birthdate,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
                PlaySince = input.PlaySince,
                PlayFrequencyInHoursPerWeek = input.PlayFrequencyInHoursPerWeek,
                PreferredSurface = input.PreferredSurface,
                Years = input.Years,
                UserId = userId,
            };

            await this.playersRepository.AddAsync(player);
            await this.playersRepository.SaveChangesAsync();
        }
    }
}
