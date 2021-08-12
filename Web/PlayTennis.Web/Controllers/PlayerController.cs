namespace PlayTennis.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PlayTennis.Data;
    using PlayTennis.Data.Models;
    using PlayTennis.Services.Data;
    using PlayTennis.Web.ViewModels.Club;
    using PlayTennis.Web.ViewModels.Player;

    using static PlayTennis.Web.WebConstants;

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

        [Authorize]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddAsync(PlayerInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            if (!this.ModelState.IsValid)
            {
              return this.View(input);
            }

            if (this.playerService.IsATrainer(user.Id) || this.playerService.IsRegistered(user.Id))
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

            this.TempData[GlobalMessageKey] = "Player added successfully.";

            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize]
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

        [Authorize]
        public ActionResult Details(int id)
        {
            var trainer = this.playerService.GetById(id);
            return this.View(trainer);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddToFavorites(int clubId)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            await this.playerService.AddToFavoritesAsync(clubId, user.Id);
            return this.Redirect("/Player/MyFavoriteClubs");
        }

        [Authorize]
        public ActionResult MyfavoriteClubs(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            const int itemsPerPage = 12;
            var clubs = this.playerService.GetAllFavorites(userId, 1, itemsPerPage);
            var viewModel = new AllClubsViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                Clubs = clubs,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> DeleteFromFavorites(int clubId)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            await this.playerService.DeleteFromFavoritesAsync(clubId, user.Id);
            return this.Redirect("/Player/MyFavoriteClubs");
        }
    }
}
