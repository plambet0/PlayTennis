namespace PlayTennis.Web.ViewModels.Reservation
{
    using System.Collections.Generic;

    public class AllReservationListViewModel
    {
        public IEnumerable<ReservationListViewModel> Reservations { get; set; }
    }
}
