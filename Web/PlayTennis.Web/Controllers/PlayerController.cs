namespace PlayTennis.Web.Controllers
{
    using System;

    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PlayTennis.Data;
    using PlayTennis.Data.Models;
    using PlayTennis.Services.Data;
    using PlayTennis.Web.ViewModels.Player;

    public class PlayerController : Controller
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

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(PlayerInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
              return this.View(input);
            }

            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await this.userManager.GetUserAsync(this.User);
            if (this.playerService.IsATrainer(user.Id))
            {
                return this.View("YouCannotRegisterAPlayer");
            }
            try
            {
                await this.playerService.CreateAsync(input, user.Id);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            this.TempData["Message"] = "Player added successfully.";

            return this.RedirectToAction(nameof(this.All));
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

        public IActionResult Details(int playerId)
        {
            return this.View();
        }
    }
}
