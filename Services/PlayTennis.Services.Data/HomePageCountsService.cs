
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

        public HomePageCountsService(IRepository<Player> playerRepository,
            IRepository<Reservation> reservationRepository,
            IRepository<Club> clubRepostirory)
        {
            this.playerRepository = playerRepository;
            this.reservationRepository = reservationRepository;
            this.clubRepostirory = clubRepostirory;
        }

        public IndexViewModel GetCounts()
        {
            var data = new IndexViewModel
            {
                ClubsCount = this.clubRepostirory.All().Count(),
                Players = this.playerRepository.All().Count(),
                Reservations = this.reservationRepository.All().Count(),
            };

            return data;
        }
    }
}
