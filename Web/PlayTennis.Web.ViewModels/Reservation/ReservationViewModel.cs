namespace PlayTennis.Web.ViewModels.Reservation
{
    using System.ComponentModel.DataAnnotations;

    public class ReservationViewModel
    {
        public int ClubId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Town { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }
    }
}
