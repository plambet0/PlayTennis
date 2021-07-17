namespace PlayTennis.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using PlayTennis.Services.Data;
    using PlayTennis.Web.ViewModels;
    using PlayTennis.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IHomePageCountsService homePageCountsService;

        public HomeController(IHomePageCountsService homePageCountsService)
        {
            this.homePageCountsService = homePageCountsService;
        }
        
        
        public IActionResult Index()
        {
            
            var counts = this.homePageCountsService.GetCounts();

            var viewModel = new IndexViewModel
            {
                 ClubsCount = counts.ClubsCount,
                 Players = counts.Players,
                 Reservations = counts.Reservations,
            };
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

      
    }
}
