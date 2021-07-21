using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlayTennis.Data.Models;
using PlayTennis.Services.Data;
using PlayTennis.Web.ViewModels.Trainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayTennis.Web.Controllers
{
    public class TrainerController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ITrainersService trainersService;

        public TrainerController(UserManager<ApplicationUser> userManager, ITrainersService trainersService)
        {
            this.userManager = userManager;
            this.trainersService = trainersService;
        }
        
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TrainerInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }
            
            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await this.userManager.GetUserAsync(this.User);
            if (this.trainersService.IsAPlayer(user.Id))
            {
                return this.View("YouCannotRegisterATrainer");
            }
            try
            {
                await this.trainersService.CreateAsync(input, user.Id);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            this.TempData["Message"] = "Trainer added successfully.";

            return this.Redirect("/");
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int itemsPerPage = 12;
            var trainers = this.trainersService.GetAll(1, itemsPerPage);
            var viewModel = new AllTrainersViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                Trainers = trainers,
            };
            return this.View(viewModel);
        }
    }
}
