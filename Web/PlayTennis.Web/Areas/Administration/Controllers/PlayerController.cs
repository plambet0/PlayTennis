namespace PlayTennis.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PlayTennis.Data;
    using PlayTennis.Data.Models;
    using PlayTennis.Services.Data;
    using PlayTennis.Web.ViewModels.Player;

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
            var players = this.playerService.GetAll(1, itemsPerPage);
            var viewModel = new AllPlayersViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                Players = players,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.playerService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
