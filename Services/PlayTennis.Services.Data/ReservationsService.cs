using PlayTennis.Data.Common.Repositories;
using PlayTennis.Data.Models;
using PlayTennis.Web.ViewModels.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Services.Data
{
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
        
        public async Task CreateAsync(ReservationViewModel input, int playerId, DateTime dateTime, int clubId)
        {
            var reservation = new Reservation
            {
                PlayerId = playerId,
                ClubId = clubId,
                DateTime = dateTime,
                 
            };
            await this.reservationRepository.AddAsync(reservation);
            await this.reservationRepository.SaveChangesAsync();
        }

        public IEnumerable<ReservationListViewModel> GetAllById(string userId)
        {
            var player = this.playersService.GetById(userId);
            
            var reservations = this.reservationRepository.All().Where(x => x.PlayerId == player.Id)
                .Select(x => new ReservationListViewModel
                {
                    Id = x.Id,
                    ClubAddress = x.Club.Address,
                    ClubCityName = x.Club.Town.ToString(),
                    ClubName = x.Club.Name,
                    DateTime = x.DateTime,
                    UserEmail = x.Player.Email,
                    ClubId = x.ClubId,


                }).ToList();
                
            return reservations;
        }
    }
}
