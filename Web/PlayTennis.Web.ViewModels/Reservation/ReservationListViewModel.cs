namespace PlayTennis.Web.ViewModels.Reservation
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ReservationListViewModel
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public int ClubId { get; set; }

        public string ClubName { get; set; }

        public string ClubCityName { get; set; }

        public string ClubAddress { get; set; }
    }
}
