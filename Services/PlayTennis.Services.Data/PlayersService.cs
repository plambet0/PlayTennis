namespace PlayTennis.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using PlayTennis.Data.Common.Repositories;
    using PlayTennis.Data.Models;
    using PlayTennis.Web.ViewModels.Club;
    using PlayTennis.Web.ViewModels.Player;

    public class PlayersService : IPlayersService
    {
        private readonly IRepository<Player> playersRepository;
        private readonly IRepository<Trainer> trainerRepository;
        private readonly IRepository<Club> clubRepository;
        private readonly IRepository<ApplicationUser> userRepository;
        private readonly IRepository<UserClub> userClubsRepostiroty;

        public PlayersService(IRepository<Player> playersRepository, IRepository<Trainer> trainerRepository, IRepository<Club> clubRepository,
            IRepository<ApplicationUser> userRepository, IRepository<UserClub> userClubsRepostiroty)
        {
            this.playersRepository = playersRepository;
            this.trainerRepository = trainerRepository;
            this.clubRepository = clubRepository;
            this.userRepository = userRepository;
            this.userClubsRepostiroty = userClubsRepostiroty;
        }

        public async Task AddToFavoritesAsync(int clubId, string userId)
        {
            var club = this.clubRepository.All().Where(x => x.Id == clubId).FirstOrDefault();
            var user = this.userRepository.All().Where(x => x.Id == userId).FirstOrDefault();
            
            user.FavoriteClubs.Add(new UserClub
            {
                UserId = userId,
                ClubId = clubId,
            });


            await this.userRepository.SaveChangesAsync();
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

        public async Task DeleteFromFavoritesAsync(int clubId, string userId)
        {

            var club = this.clubRepository.All().Where(x => x.Id == clubId).FirstOrDefault();
            var user = this.userRepository.All().Where(x => x.Id == userId).FirstOrDefault();
            var clubToDelete = this.userClubsRepostiroty.All().Where(x => x.UserId == userId && x.ClubId == clubId).FirstOrDefault();
            if (clubToDelete == null)
            {
                return;
            }
            this.userClubsRepostiroty.Delete(clubToDelete);
            await this.userClubsRepostiroty.SaveChangesAsync();



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

        public IEnumerable<ClubsViewModel> GetAllFavorites(string userId, int page, int itemsPerPage = 12)
        {
            var user = this.userRepository.All().Where(x => x.Id == userId).FirstOrDefault();
            var clubs = this.userClubsRepostiroty.All().Where(x => x.UserId == userId);
            return clubs
                 .OrderByDescending(x => x.ClubId)
                 .Skip((page - 1) * itemsPerPage)
                 .Take(itemsPerPage)
                 .Select(x => new ClubsViewModel
            {
                Address = x.Club.Address,
                ImageUrl = x.Club.ImageUrl,
                Name = x.Club.Name,
                PricePerHour = x.Club.PricePerHour,
                Surface = x.Club.Surface.ToString(),
                Town = x.Club.Town.ToString(),
                Courts = x.Club.Courts,
                Id = x.Club.Id,
            }).ToList();
        }

        public PlayerInputModel GetById(int id)
        {
            var player = this.playersRepository.All().Where(x => x.Id == id)
                .Select(x => new PlayerInputModel
                {
                     FirstName = x.FirstName,
                     LastName = x.LastName,
                     Gender = x.Gender,
                     Email = x.Email,
                     BackHand = x.BackHand,
                     PhoneNumber = x.PhoneNumber,
                     Hand = x.Hand,
                     ImageUrl = x.ImageUrl,
                     PlayFrequencyInHoursPerWeek = x.PlayFrequencyInHoursPerWeek,
                     PlaySinceInYears = x.PlaySinceInYears,
                     PreferredSurface = x.PreferredSurface,
                     Town = x.Town,
                     Years = x.Years,

                }).FirstOrDefault();

            return player;
        }

        public bool IsATrainer(string userId)
        {
            var trainer = this.trainerRepository.All().Where(x => x.UserId == userId).FirstOrDefault();
            if (trainer == null)
            {
                return false;
            }

            return true;
        }

        public bool IsRegistered(string userId)
        {
            var player = this.playersRepository.All().Where(x => x.UserId == userId).FirstOrDefault();
            if (player == null)
            {
                return false;
            }

            return true;
        }
    }
}
