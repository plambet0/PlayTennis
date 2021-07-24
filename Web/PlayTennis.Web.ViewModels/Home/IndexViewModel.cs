namespace PlayTennis.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PlayTennis.Web.ViewModels.Player;

    public class IndexViewModel
    {

        public int ClubsCount { get; set; }

        public int Players { get; set; }

        public int Trainers { get; set; }

        public int Reservations { get; set; }
    }
}
