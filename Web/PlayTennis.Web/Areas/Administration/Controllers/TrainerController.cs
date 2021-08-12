namespace PlayTennis.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PlayTennis.Data.Models;
    using PlayTennis.Services.Data;
    using PlayTennis.Web.ViewModels.Trainer;

    using static PlayTennis.Web.WebConstants;

    public class TrainerController : AdministrationController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ITrainersService trainersService;

        public TrainerController(UserManager<ApplicationUser> userManager, ITrainersService trainersService)
        {
            this.userManager = userManager;
            this.trainersService = trainersService;
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int itemsPerPage = 12;
            var trainers = this.trainersService.GetAll(id, itemsPerPage);
            var viewModel = new AllTrainersViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                Trainers = trainers,
                ItemsCount = this.trainersService.GetCount(),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.trainersService.DeleteAsync(id);
            this.TempData[GlobalMessageKey] = "Trainer deleted successfully.";
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
