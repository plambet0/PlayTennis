﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlayTennis.Web.ViewModels.Trainer
{
    public class TrainerViewModel
    {
        public string ImageUrl { get; set; }

        public string FullName { get; set; }

        public string Town { get; set; }

        public string PhoneNumber { get; set; }

        public decimal PricePerHour { get; set; }
    }
}