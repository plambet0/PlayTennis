namespace PlayTennis.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(ClubInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await this.userManager.GetUserAsync(this.User);
            try
            {
                await this.clubsService.CreateAsync(input, user.Id);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            this.TempData["Message"] = "Club added successfully.";

            return this.RedirectToAction(nameof(this.All));
        }

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

        public ActionResult Details(int id)
        {
            var club = this.clubsService.GetById(id);
            return this.View(club);
        }

       
        
    }
}
