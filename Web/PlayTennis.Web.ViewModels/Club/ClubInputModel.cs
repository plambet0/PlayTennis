using System;
using System.ComponentModel.DataAnnotations;
using PlayTennis.Data.Models;

namespace PlayTennis.Web.ViewModels.Club
{
    public class ClubInputModel
    {
        [Required]
        [MaxLength(30)]
        [Display(Name = "The Name of the Club")]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Range(1,12)]
        [Display(Name = "Number of courts for play")]
        public int Courts { get; set; }

        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        [Display(Name = "Price per hour (lv.)")]
        public decimal PricePerHour { get; set; }

        public Surface Surface { get; set; }

        public Town Town { get; set; }
    }
}
