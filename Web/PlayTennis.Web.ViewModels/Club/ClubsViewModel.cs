

using System.ComponentModel.DataAnnotations;

namespace PlayTennis.Web.ViewModels.Club
{
    public class ClubsViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public int Courts { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public decimal PricePerHour { get; set; }

        public string Surface { get; set; }

        public string Town { get; set; }
    }
}
