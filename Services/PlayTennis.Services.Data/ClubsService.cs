using PlayTennis.Data.Common.Repositories;
using PlayTennis.Data.Models;
using PlayTennis.Web.ViewModels.Club;
using System;
using System.Collections.Generic;
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
    }
}
