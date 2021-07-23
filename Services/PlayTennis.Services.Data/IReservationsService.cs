using PlayTennis.Web.ViewModels.Reservation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Services.Data
{
    public interface IReservationsService
    {
        Task CreateAsync(ReservationViewModel input, int playerId, DateTime dateTime, int clubId);

        IEnumerable<ReservationListViewModel> GetAllById(string userId);
    }
}
