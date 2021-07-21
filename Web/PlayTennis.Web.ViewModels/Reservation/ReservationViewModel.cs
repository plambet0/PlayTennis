
namespace PlayTennis.Web.ViewModels.Reservation
{
    using System.ComponentModel.DataAnnotations;

    public class ReservationViewModel
    {
        [Required]
        public int ClubId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Town { get; set; }

        [Required]

        public string Date { get; set; }

        [Required]

        public string Time { get; set; }
    }
}
