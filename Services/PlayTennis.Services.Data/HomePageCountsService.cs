namespace PlayTennis.Services.Data
{
    using System.Linq;

    using PlayTennis.Data.Common.Repositories;
    using PlayTennis.Data.Models;
    using PlayTennis.Web.ViewModels.Home;

    public class HomePageCountsService : IHomePageCountsService
    {
        private readonly IRepository<Player> playerRepository;
        private readonly IRepository<Reservation> reservationRepository;
        private readonly IRepository<Club> clubRepostirory;
        private readonly IRepository<Trainer> trainerRepository;

        public HomePageCountsService(
            IRepository<Player> playerRepository,
            IRepository<Reservation> reservationRepository,
            IRepository<Club> clubRepostirory,
            IRepository<Trainer> trainerRepository)
        {
            this.playerRepository = playerRepository;
            this.reservationRepository = reservationRepository;
            this.clubRepostirory = clubRepostirory;
            this.trainerRepository = trainerRepository;
        }

        public IndexViewModel GetCounts()
        {
            var data = new IndexViewModel
            {
                ClubsCount = this.clubRepostirory.All().Count(),
                Players = this.playerRepository.All().Count(),
                Reservations = this.reservationRepository.All().Count(),
                Trainers = this.trainerRepository.All().Count(),
            };

            return data;
        }
    }
}
