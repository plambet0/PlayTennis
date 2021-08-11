namespace PlayTennis.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PlayTennis.Common;
    using PlayTennis.Data;
    using PlayTennis.Data.Models;
    using PlayTennis.Services.Data;
    using PlayTennis.Web.ViewModels.Club;

    public class ClubController : Controller
    {
        private readonly IClubsService clubsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext applicationDbContext;

        public ClubController(
            IClubsService clubsService,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext applicationDbContext)
        {
            this.clubsService = clubsService;
            this.userManager = userManager;
            this.applicationDbContext = applicationDbContext;
        }

        [Authorize]
        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int itemsPerPage = 12;
            var clubs = this.clubsService.GetAll(1, itemsPerPage);
            var viewModel = new AllClubsViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                Clubs = clubs,
            };
            return this.View(viewModel);
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var club = this.clubsService.GetById(id);
            return this.View(club);
        }
    }
}
