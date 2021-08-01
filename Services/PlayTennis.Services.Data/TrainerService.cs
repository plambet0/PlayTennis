using PlayTennis.Data.Common.Repositories;
using PlayTennis.Data.Models;
using PlayTennis.Web.ViewModels.Trainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Services.Data
{
    public class TrainerService : ITrainersService
    {
        private readonly IRepository<Trainer> trainerRepository;
        private readonly IRepository<Player> playerRepository;

        public TrainerService(IRepository<Trainer> trainerRepository, IRepository<Player> playerRepository)
        {
            this.trainerRepository = trainerRepository;
            this.playerRepository = playerRepository;
        }
        
        public async Task CreateAsync(TrainerInputModel input, string userId)
        {
            var trainer = new Trainer
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Gender = input.Gender,
                Email = input.Email,
                PricePerHour = input.PricePerHour,
                ImageUrl = input.ImageUrl,
                Town = input.Town,
                PhoneNumber = input.PhoneNumber,
                TrainerSinceInYears = input.TrainerSinceInYears,
                UserId = userId,
            };

            await this.trainerRepository.AddAsync(trainer);
            await this.trainerRepository.SaveChangesAsync();
        }

        public IEnumerable<TrainerViewModel> GetAll(int page, int itemsPerPage = 12)
        {
            var trainers = this.trainerRepository.AllAsNoTracking()
                 .OrderByDescending(x => x.Id)
                 .Skip((page - 1) * itemsPerPage)
                 .Take(itemsPerPage)
                 .Select(x => new TrainerViewModel
                 {

                     FullName = x.FirstName + " " + x.LastName,
                     ImageUrl = x.ImageUrl,
                     Town = x.Town.ToString(),
                     PricePerHour = x.PricePerHour,
                     PhoneNumber = x.PhoneNumber,
                     Id = x.Id,
                 })
                 .ToList();
            return trainers;
        }

        public TrainerDetailsViewModel GetById(int id)
        {
            var trainer = this.trainerRepository.All().Where(x => x.Id == id).Select(x => new TrainerDetailsViewModel
            {
                 
                 FirstName = x.FirstName,
                 LastName = x.LastName,
                 Email = x.Email,
                 Gender = x.Gender,
                 TrainerSinceInYears = x.TrainerSinceInYears,
                 Years = x.Years,
                 ImageUrl = x.ImageUrl,
                 PhoneNumber = x.PhoneNumber,
                 PricePerHour = x.PricePerHour,
                 Town = x.Town,
                 TrainerVoteAverageValue = x.Votes.Count() == 0 ? 0 : x.Votes.Average(v => v.Value),
                 Id = x.Id,
                
            }).FirstOrDefault();

            return trainer;
        }

        public bool IsAPlayer(string userId)
        {
            var player = this.playerRepository.All().Where(x => x.UserId == userId).FirstOrDefault();
            if (player == null)
            {
                return false;
            }

            return true;
        }

        public bool IsRegistered(string userId)
        {
            var trainer = this.trainerRepository.All().Where(x => x.UserId == userId).FirstOrDefault();
            if (trainer == null)
            {
                return false;
            }

            return true;
        }
    }
}
