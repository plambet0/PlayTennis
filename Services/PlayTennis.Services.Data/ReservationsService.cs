using PlayTennis.Data.Common.Repositories;
using PlayTennis.Data.Models;
using PlayTennis.Web.ViewModels.Reservation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Services.Data
{
    public class ReservationsService : IReservationsService
    {
        private readonly IDateTimeParseService dateTimeParseService;
        private readonly IRepository<Reservation> reservationRepository;

        public ReservationsService(IDateTimeParseService dateTimeParseService, IRepository<Reservation> reservationRepository)
        {
            this.dateTimeParseService = dateTimeParseService;
            this.reservationRepository = reservationRepository;
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
    }
}
