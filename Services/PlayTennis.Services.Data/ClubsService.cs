namespace PlayTennis.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using PlayTennis.Data.Common.Repositories;
    using PlayTennis.Data.Models;
    using PlayTennis.Web.ViewModels.Club;

    public class ClubsService : IClubsService
    {
        private readonly IRepository<Club> clubRepository;
        private readonly IRepository<Player> playerRepository;
        private readonly IRepository<PlayerClubs> playerClubsRepository;

        public ClubsService(IRepository<Club> clubRepository, IRepository<Player> playerRepository, IRepository<PlayerClubs> playerClubsRepository)
        {
            this.clubRepository = clubRepository;
            this.playerRepository = playerRepository;
            this.playerClubsRepository = playerClubsRepository;
        }

        public async Task AddToFavoritesAsync(int id, string userId)
        {
            var club = this.clubRepository.All().Where(x => x.Id == id).FirstOrDefault();
            var player = this.playerRepository.All().Where(x => x.UserId == userId).FirstOrDefault();
            await this.playerClubsRepository.AddAsync(new PlayerClubs
            {
                ClubId = club.Id,
                PlayerId = player.Id,
            });

            await this.playerClubsRepository.SaveChangesAsync();

        }

        public async Task CreateAsync(ClubInputModel input, string userId)
        {
            var club = new Club
            {
                Name = input.Name,
                Town = input.Town,
                Address = input.Address,
                Courts = input.Courts,
                ImageUrl = input.ImageUrl,
                Surface = input.Surface,
                PricePerHour = input.PricePerHour,
                AddedByUserId = userId,
            };
            await this.clubRepository.AddAsync(club);
            await this.clubRepository.SaveChangesAsync();
        }

        public IEnumerable<ClubsViewModel> GetAll(int page, int itemsPerPage = 12)
        {
            var clubs = this.clubRepository.AllAsNoTracking()
                 .OrderByDescending(x => x.Id)
                 .Skip((page - 1) * itemsPerPage)
                 .Take(itemsPerPage)
                 .Select(x => new ClubsViewModel
                 {
                     Name = x.Name,
                     Address = x.Address,
                     ImageUrl = x.ImageUrl,
                     Courts = x.Courts,
                     PricePerHour = x.PricePerHour,
                     Surface = x.Surface.ToString(),
                     Town = x.Town.ToString(),
                     Id = x.Id,
                 })
                 .ToList();
            return clubs;
        }

        public IEnumerable<ClubsViewModel> GetAllById(string userId)
        {
            var player = this.playerRepository.All().Where(x => x.UserId == userId).FirstOrDefault();

            var clubs = this.clubRepository.All().Where(x => x.PlayersClubs.All(x => x.PlayerId == player.Id));

            var dbClubs = clubs.Select(x => new ClubsViewModel
             {
                 Name = x.Name,
                 Address = x.Address,
                 ImageUrl = x.ImageUrl,
                 Courts = x.Courts,
                 PricePerHour = x.PricePerHour,
                 Surface = x.Surface.ToString(),
                 Town = x.Town.ToString(),
                 Id = x.Id,
             }).ToList();

            return dbClubs;
        }

        public ClubsViewModel GetById(int id)
        {
            var club = this.clubRepository.All().Where(x => x.Id == id).Select(x => new ClubsViewModel
            {
                Id = x.Id,
                Address = x.Address,
                ImageUrl = x.ImageUrl,
                Courts = x.Courts,
                Name = x.Name,
                PricePerHour = x.PricePerHour,
                Surface = x.Surface.ToString(),
                Town = x.Town.ToString(),
            }).FirstOrDefault();

            return club;
        }
    }
}
