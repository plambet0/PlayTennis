namespace PlayTennis.Web.Areas.Administration.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PlayTennis.Data;
    using PlayTennis.Data.Models;
    using PlayTennis.Services.Data;
    using PlayTennis.Web.ViewModels.Club;

    using static PlayTennis.Web.WebConstants;

    public class ClubController : AdministrationController
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

            this.TempData[GlobalMessageKey] = "Club added successfully.";

            return this.RedirectToAction(nameof(this.All));
        }

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

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.clubsService.DeleteAsync(id);

            this.TempData[GlobalMessageKey] = "Club deleted successfully.";
            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Edit(int id)
        {
            var inputModel = this.clubsService.EditById(id);
            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditClubInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            this.TempData[GlobalMessageKey] = "Club edited successfully.";

            await this.clubsService.UpdateAsync(id, input);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
