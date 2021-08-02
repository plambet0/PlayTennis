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
        private readonly IRepository<UserClub> playerClubsRepository;

        public ClubsService(IRepository<Club> clubRepository, IRepository<Player> playerRepository, IRepository<UserClub> playerClubsRepository)
        {
            this.clubRepository = clubRepository;
            this.playerRepository = playerRepository;
            this.playerClubsRepository = playerClubsRepository;
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
        public ClubDetailsViewModel GetById(int id)
        {
            var club = this.clubRepository.All().Where(x => x.Id == id).Select(x => new ClubDetailsViewModel
            {
                Address = x.Address,
                ImageUrl = x.ImageUrl,
                Courts = x.Courts,
                Name = x.Name,
                PricePerHour = x.PricePerHour,
                Surface = x.Surface.ToString(),
                Town = x.Town.ToString(),
                ClubVoteAverageValue = x.Votes.Count() == 0 ? 0 : x.Votes.Average(v => v.Value),
                Id = x.Id,
            }).FirstOrDefault();

            return club;
        }
    }
}
