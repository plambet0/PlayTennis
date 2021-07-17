﻿
namespace PlayTennis.Web.ViewModels.Player
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using PlayTennis.Data.Models;

    public class PlayerInputModel
    {
        

        [Required]
        [MaxLength(10)]
        public string FirstName { get; set; }

        [Required]

        [MaxLength(10)]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        [Range(1, 100)]
        public int Years { get; set; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        public Hand Hand { get; set; }

        public BackHand BackHand { get; set; }

        [Display(Name = "Prefered Surface")]
        public Surface PreferredSurface { get; set; }

        [Display(Name = "Play since (years)")]
        public int PlaySinceInYears { get; set; }

        [Display(Name = "Play frequency per week (hours)")]
        public int PlayFrequencyInHoursPerWeek { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public Town Town { get; set; }
    }
}