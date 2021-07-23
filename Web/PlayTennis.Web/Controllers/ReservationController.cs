namespace PlayTennis.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PlayTennis.Data;
    using PlayTennis.Data.Models;
    using PlayTennis.Services;
    using PlayTennis.Services.Data;
    using PlayTennis.Web.ViewModels.Reservation;

    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IDateTimeParseService dateTimeParseService;
        private readonly IReservationsService reservationsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPlayersService playersService;

        public ReservationController(ApplicationDbContext db, IDateTimeParseService dateTimeParseService, IReservationsService reservationsService,
            UserManager<ApplicationUser> userManager, IPlayersService playersService)
        {
            this.db = db;
            this.dateTimeParseService = dateTimeParseService;
            this.reservationsService = reservationsService;
            this.userManager = userManager;
            this.playersService = playersService;
        }
        public IActionResult All()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            

            var reservations = this.reservationsService.GetAllById(userId);
            var viewModel = new AllReservationListViewModel
            {
              
                Reservations = reservations,
            };
            return this.View(viewModel);
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

        [HttpPost]
        public async Task<IActionResult> MakeAReservation(ReservationViewModel input, int id)
        {

            var club = this.db.Clubs.Where(x => x.Id == id).FirstOrDefault();
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var player = this.db.Players.Where(x => x.UserId == userId).FirstOrDefault();
            var clubId = id;

            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("MakeAReservation");
            }

            DateTime dateTime;
            
            dateTime = this.dateTimeParseService.ConvertStrings(input.Date, input.Time);
            
            try
            {
                await this.reservationsService.CreateAsync(input, player.Id, dateTime, clubId);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            this.TempData["Message"] = "Reservation added successfully.";

            return this.Redirect("/");
        }
    }
}
