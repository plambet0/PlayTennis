namespace PlayTennis.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using PlayTennis.Data;
    using PlayTennis.Data.Models;
    using PlayTennis.Data.Repositories;
    using PlayTennis.Web.ViewModels.Trainer;
    using Xunit;

    public class TrainerServiceTests
    {
        [Fact]
        public async Task CreateTrainerShouldCreateTrainer()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "Trainer_CreateTrainer_Database")
                    .Options;
            var dbContext = new ApplicationDbContext(options);
            var trainersService = new TrainerService(new EfRepository<Trainer>(dbContext), new EfRepository<Player>(dbContext));
            var userId = Guid.NewGuid().ToString();

            var viewModel = new TrainerInputModel()
            {
                FirstName = "Boris",
                LastName = "Becker",
                Email = "borisbecker@gmail.com",
                Gender = Gender.Male,
                PhoneNumber = "0888888888",
                PricePerHour = 20,
                Town = Town.Варна,
                TrainerSinceInYears = 10,
                Years = 44,
                ImageUrl = "https://i.inews.co.uk/content/uploads/2021/07/SEI_86403193.jpg",
            };

            await trainersService.CreateAsync(viewModel, userId);

            var trainersCount = dbContext.Trainers.ToArray().Count();

            Assert.Equal(1, trainersCount);
        }

        [Fact]
        public async Task DeleteTrainerShouldDeleteTrainer()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "Trainer_DeleteTrainer_Database")
                    .Options;
            var dbContext = new ApplicationDbContext(options);
            var trainersService = new TrainerService(new EfRepository<Trainer>(dbContext), new EfRepository<Player>(dbContext));
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser()
            {
                Id = userId,
                UserName = "Test",
            };

            var trainer = new Trainer()
            {
                FirstName = "Boris",
                LastName = "Becker",
                Email = "borisbecker@gmail.com",
                Gender = Gender.Male,
                PhoneNumber = "0888888888",
                PricePerHour = 20,
                Town = Town.Варна,
                TrainerSinceInYears = 10,
                Years = 44,
                ImageUrl = "https://i.inews.co.uk/content/uploads/2021/07/SEI_86403193.jpg",
                Id = 1,
                UserId = user.Id,
            };
            dbContext.Trainers.Add(trainer);
            dbContext.SaveChanges();
            await trainersService.DeleteAsync(1);
            Assert.Equal(0, dbContext.Clubs.Count());
        }

        [Fact]
        public void GetTrainerByIdShouldReturnTrainer()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "Trainer_GetTrainerById_Database")
                    .Options;
            var dbContext = new ApplicationDbContext(options);
            var trainerService = new TrainerService(new EfRepository<Trainer>(dbContext), new EfRepository<Player>(dbContext));
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser()
            {
                Id = userId,
                UserName = "Test",
            };

            var trainer = new Trainer()
            {
                FirstName = "Boris",
                LastName = "Becker",
                Email = "borisbecker@gmail.com",
                Gender = Gender.Male,
                PhoneNumber = "0888888888",
                PricePerHour = 20,
                Town = Town.Варна,
                TrainerSinceInYears = 10,
                Years = 44,
                ImageUrl = "https://i.inews.co.uk/content/uploads/2021/07/SEI_86403193.jpg",
                Id = 1,
                UserId = user.Id,
            };
            dbContext.Trainers.Add(trainer);
            dbContext.SaveChanges();

            var trainerById = trainerService.GetById(trainer.Id);
            Assert.Equal(trainer.FirstName, trainerById.FirstName);
        }

        [Fact]

        public void GetAllShouldReturnAllTrainers()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "Trainer_GetAllTrainers_Database")
                    .Options;
            var dbContext = new ApplicationDbContext(options);
            var trainerService = new TrainerService(new EfRepository<Trainer>(dbContext), new EfRepository<Player>(dbContext));
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser()
            {
                Id = userId,
                UserName = "Test",
            };
            var trainers = new List<Trainer>
            {
                new Trainer
                {
                FirstName = "Boris",
                LastName = "Becker",
                Email = "borisbecker@gmail.com",
                Gender = Gender.Male,
                PhoneNumber = "0888888888",
                PricePerHour = 20,
                Town = Town.Варна,
                TrainerSinceInYears = 10,
                Years = 44,
                ImageUrl = "https://i.inews.co.uk/content/uploads/2021/07/SEI_86403193.jpg",
                Id = 1,
                UserId = user.Id,
                },
                new Trainer
                {
                FirstName = "Pete",
                LastName = "Sampras",
                Email = "petesampras@gmail.com",
                Gender = Gender.Male,
                PhoneNumber = "0888888808",
                PricePerHour = 20,
                Town = Town.Варна,
                TrainerSinceInYears = 10,
                Years = 44,
                ImageUrl = "https://i.inews.co.uk/content/uploads/2021/07/SEI_86403193.jpg",
                Id = 2,
                UserId = user.Id,
                },
            };
            int page = 1;
            int itemsPerPage = 12;
            dbContext.Trainers.AddRange(trainers);
            dbContext.SaveChanges();
            var count = trainerService.GetAll(page, itemsPerPage).Count();
            Assert.Equal(2, count);
        }

        [Fact]

        public void GetCountShouldReturnTheCountOfTrainers()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "Trainer_GetTrainersCount_Database")
                    .Options;
            var dbContext = new ApplicationDbContext(options);
            var trainerService = new TrainerService(new EfRepository<Trainer>(dbContext), new EfRepository<Player>(dbContext));
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser()
            {
                Id = userId,
                UserName = "Test",
            };
            var trainers = new List<Trainer>
            {
                new Trainer
                {
                FirstName = "Boris",
                LastName = "Becker",
                Email = "borisbecker@gmail.com",
                Gender = Gender.Male,
                PhoneNumber = "0888888888",
                PricePerHour = 20,
                Town = Town.Варна,
                TrainerSinceInYears = 10,
                Years = 44,
                ImageUrl = "https://i.inews.co.uk/content/uploads/2021/07/SEI_86403193.jpg",
                Id = 1,
                UserId = user.Id,
                },
                new Trainer
                {
                FirstName = "Pete",
                LastName = "Sampras",
                Email = "petesampras@gmail.com",
                Gender = Gender.Male,
                PhoneNumber = "0888888808",
                PricePerHour = 20,
                Town = Town.Варна,
                TrainerSinceInYears = 10,
                Years = 44,
                ImageUrl = "https://i.inews.co.uk/content/uploads/2021/07/SEI_86403193.jpg",
                Id = 2,
                UserId = user.Id,
                },
            };
            dbContext.Trainers.AddRange(trainers);
            dbContext.SaveChanges();
            var count = trainerService.GetCount();
            Assert.Equal(2, count);
        }

        [Fact]

        public void IsRegisteredMethodShouldWorkCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                     .UseInMemoryDatabase(databaseName: "Trainer_IsRegistered_Database")
                     .Options;
            var dbContext = new ApplicationDbContext(options);
            var trainersService = new TrainerService(new EfRepository<Trainer>(dbContext), new EfRepository<Player>(dbContext));
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser()
            {
                Id = userId,
                UserName = "Test",
            };

            var trainer = new Trainer()
            {
                FirstName = "Boris",
                LastName = "Becker",
                Email = "borisbecker@gmail.com",
                Gender = Gender.Male,
                PhoneNumber = "0888888888",
                PricePerHour = 20,
                Town = Town.Варна,
                TrainerSinceInYears = 10,
                Years = 44,
                ImageUrl = "https://i.inews.co.uk/content/uploads/2021/07/SEI_86403193.jpg",
                Id = 1,
                UserId = user.Id,
            };
            dbContext.Trainers.Add(trainer);
            dbContext.SaveChanges();

            var isRegistered = trainersService.IsRegistered(userId);
            Assert.True(isRegistered);
        }

        [Fact]

        public void IsAPlayerdMethodShouldWorkCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                     .UseInMemoryDatabase(databaseName: "Trainer_IsAPlayer_Database")
                     .Options;
            var dbContext = new ApplicationDbContext(options);
            var trainersService = new TrainerService(new EfRepository<Trainer>(dbContext), new EfRepository<Player>(dbContext));
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser()
            {
                Id = userId,
                UserName = "Test",
            };

            var trainer = new Trainer()
            {
                FirstName = "Boris",
                LastName = "Becker",
                Email = "borisbecker@gmail.com",
                Gender = Gender.Male,
                PhoneNumber = "0888888888",
                PricePerHour = 20,
                Town = Town.Варна,
                TrainerSinceInYears = 10,
                Years = 44,
                ImageUrl = "https://i.inews.co.uk/content/uploads/2021/07/SEI_86403193.jpg",
                Id = 1,
                UserId = user.Id,
            };
            dbContext.Trainers.Add(trainer);
            dbContext.SaveChanges();

            var isAPlayer = trainersService.IsAPlayer(userId);
            Assert.False(isAPlayer);
        }
    }
}
