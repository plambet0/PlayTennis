using PlayTennis.Data.Common.Repositories;
using PlayTennis.Data.Models;
using PlayTennis.Web.ViewModels.Club;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Services.Data
{
    public class ClubsService : IClubsService
    {
        private readonly IRepository<Club> clubRepository;

        public ClubsService(IRepository<Club> clubRepository)
        {
            this.clubRepository = clubRepository;
        }
        
        public async Task CreateAsync(ClubInputModel input, string userId)
        {
            var club = new Club
            {
                Name = input.Name,
                Town = input.Town,
                Address = input.Address,
                Courts = input.Courts,
                ImageUrl = input.ImageUrl,
                Surface = input.Surface,
                PricePerHour = input.PricePerHour,


            };
            await this.clubRepository.AddAsync(club);
            await this.clubRepository.SaveChangesAsync();
        }

        public IEnumerable<ClubsViewModel> GetAll(int page, int itemsPerPage = 12)
        {
            var players = this.clubRepository.AllAsNoTracking()
                 .OrderByDescending(x => x.Id)
                 .Skip((page - 1) * itemsPerPage)
                 .Take(itemsPerPage)
                 .Select(x => new ClubsViewModel
                 {
                     Name = x.Name,
                     Address = x.Address,
                     ImageUrl = x.ImageUrl,
                     Courts = x.Courts,
                     PricePerHour = x.PricePerHour,
                     Surface = x.Surface.ToString(),
                     Town = x.Town.ToString(),
                     Id = x.Id,

                 })
                 .ToList();
            return players;
        }
        public ClubsViewModel GetById(int id)
        {
            var club = this.clubRepository.All().Where(x => x.Id == id).Select(x => new ClubsViewModel
            {
                Id = x.Id,
                Address = x.Address,
                ImageUrl = x.ImageUrl,
                Courts = x.Courts,
                Name = x.Name,
                PricePerHour = x.PricePerHour,
                Surface = x.Surface.ToString(),
                Town = x.Town.ToString(),
            }).FirstOrDefault();

            return club;
        }
    }
}
