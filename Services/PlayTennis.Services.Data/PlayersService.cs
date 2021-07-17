namespace PlayTennis.Services.Data
{
    using System;
    using System.Collections.Generic;
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
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
                PlayFrequencyInHoursPerWeek = input.PlayFrequencyInHoursPerWeek,
                PlaySinceInYears = input.PlaySinceInYears,
                ImageUrl = input.ImageUrl,
                PreferredSurface = input.PreferredSurface,
                Years = input.Years,
                UserId = userId,
            };

            await this.playersRepository.AddAsync(player);
            await this.playersRepository.SaveChangesAsync();
        }

        public IEnumerable<PlayersViewModel> GetAll(int page, int itemsPerPage = 12)
        {
            var players = this.playersRepository.AllAsNoTracking()
                 .OrderByDescending(x => x.Id)
                 .Skip((page - 1) * itemsPerPage)
                 .Take(itemsPerPage)
                 .Select(x => new PlayersViewModel
                 {
                      
                      FullName = x.FirstName + " " + x.LastName,
                      ImageUrl = x.ImageUrl,
                      Town = x.Town.ToString(),
                      Years = x.Years,
                      Id = x.Id,
                 })
                 .ToList();
            return players;
        }
    }
}
