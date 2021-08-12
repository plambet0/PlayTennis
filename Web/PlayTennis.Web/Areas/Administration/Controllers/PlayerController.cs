namespace PlayTennis.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PlayTennis.Data;
    using PlayTennis.Data.Models;
    using PlayTennis.Services.Data;
    using PlayTennis.Web.ViewModels.Player;

    using static PlayTennis.Web.WebConstants;

    public class PlayerController : AdministrationController
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IPlayersService playerService;
        private readonly UserManager<ApplicationUser> userManager;

        public PlayerController(
            ApplicationDbContext applicationDbContext,
            IPlayersService playerService,
            UserManager<ApplicationUser> userManager)
        {
            this.applicationDbContext = applicationDbContext;
            this.playerService = playerService;
            this.userManager = userManager;
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int itemsPerPage = 12;
            var players = this.playerService.GetAll(id, itemsPerPage);
            var viewModel = new AllPlayersViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                Players = players,
                ItemsCount = this.playerService.GetCount(),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.playerService.DeleteAsync(id);
            this.TempData[GlobalMessageKey] = "Player deleted successfully.";
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
