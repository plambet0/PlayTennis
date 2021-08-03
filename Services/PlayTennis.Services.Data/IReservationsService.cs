namespace PlayTennis.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using PlayTennis.Web.ViewModels.Reservation;

    public interface IReservationsService
    {
        Task CreateAsync(ReservationViewModel input, string userId, DateTime dateTime, int clubId);

        IEnumerable<ReservationListViewModel> GetAllById(string userId);

        ReservationListViewModel GetById(int id);

        Task DeleteAsync(int id);
    }
}
