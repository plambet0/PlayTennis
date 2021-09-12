namespace PlayTennis.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PlayTennis.Services.Data;
    using PlayTennis.Web.ViewModels.Club;

    public class ClubController : Controller
    {
        private readonly IClubsService clubsService;

        public ClubController(
            IClubsService clubsService)
        {
            this.clubsService = clubsService;
        }

        [Authorize]
        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int itemsPerPage = 12;
            var clubs = this.clubsService.GetAll(id, itemsPerPage);
            var viewModel = new AllClubsViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                Clubs = clubs,
                ItemsCount = this.clubsService.GetCount(),
            };
            return this.View(viewModel);
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var club = this.clubsService.GetById(id);
            return this.View(club);
        }

        public IActionResult GetAllByTown(string town)
        {
            var clubs = this.clubsService.GetAllByTown(town);
            var viewModel = new AllClubsViewModel
            {
                Clubs = clubs,
            };
            return this.View(viewModel);
        }
    }
}
