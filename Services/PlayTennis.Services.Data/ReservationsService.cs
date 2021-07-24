namespace PlayTennis.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using PlayTennis.Data.Common.Repositories;
    using PlayTennis.Data.Models;
    using PlayTennis.Web.ViewModels.Reservation;

    public class ReservationsService : IReservationsService
    {
        private readonly IDateTimeParseService dateTimeParseService;
        private readonly IRepository<Reservation> reservationRepository;
        private readonly IPlayersService playersService;

        public ReservationsService(IDateTimeParseService dateTimeParseService, IRepository<Reservation> reservationRepository, IPlayersService playersService)
        {
            this.dateTimeParseService = dateTimeParseService;
            this.reservationRepository = reservationRepository;
            this.playersService = playersService;
        }

        public async Task CreateAsync(ReservationViewModel input, string userId, DateTime dateTime, int clubId)
        {
            var reservation = new Reservation
            {
                UserId = userId,
                ClubId = clubId,
                DateTime = dateTime,
            };
            await this.reservationRepository.AddAsync(reservation);
            await this.reservationRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var reservation = this.reservationRepository.All().FirstOrDefault(x => x.Id == id);
            this.reservationRepository.Delete(reservation);
            await this.reservationRepository.SaveChangesAsync();
        }

        public IEnumerable<ReservationListViewModel> GetAllById(string userId)
        {
             var reservations = this.reservationRepository.All().Where(x => x.UserId == userId)
                .Select(x => new ReservationListViewModel
                {
                    Id = x.Id,
                    ClubAddress = x.Club.Address,
                    ClubCityName = x.Club.Town.ToString(),
                    ClubName = x.Club.Name,
                    DateTime = x.DateTime,
                    ClubId = x.ClubId,
                }).ToList();

             return reservations;
        }

        public ReservationListViewModel GetById(int id)
        {
            var reservation = this.reservationRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new ReservationListViewModel
                {
                    Id = id,
                    ClubAddress = x.Club.Address,
                    ClubCityName = x.Club.Name,
                    ClubId = x.ClubId,
                    ClubName = x.Club.Name,
                    DateTime = x.DateTime,
                }).FirstOrDefault();

            return reservation;
        }
    }
}
