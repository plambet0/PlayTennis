namespace PlayTennis.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PlayTennis.Data;
    using PlayTennis.Web.ViewModels.Reservation;
    using System;
    using System.Linq;

    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext db;

        public ReservationController(ApplicationDbContext db)
        {
            this.db = db;
        }
        
        public IActionResult MakeAReservation(int id)
        {

            var club = this.db.Clubs.Where(x => x.Id == id).FirstOrDefault();
            
            var viewModel = new ReservationViewModel
            {
                ClubId = id,
                Address = club.Address,
                Name = club.Name,
                Town = club.Town.ToString(),
                
            };

            return this.View(viewModel);
        }
    }
}
