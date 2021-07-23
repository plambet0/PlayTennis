
using System.Collections.Generic;

namespace PlayTennis.Web.ViewModels.Reservation
{
    public class AllReservationListViewModel
    {
        public IEnumerable<ReservationListViewModel> Reservations { get; set; }
    }
}
