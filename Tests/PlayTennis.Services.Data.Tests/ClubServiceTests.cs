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
    using PlayTennis.Web.ViewModels.Club;
    using Xunit;

    public class ClubServiceTests
    {
        [Fact]
        public async Task CreateClubShouldCreateClub()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "Club_CreateClub_Database")
                    .Options;
            var dbContext = new ApplicationDbContext(options);
            var clubsService = new ClubsService(new EfRepository<Club>(dbContext));
            var userId = Guid.NewGuid().ToString();

            var viewModel = new ClubInputModel()
            {
                Name = "Test Name",
                Address = "Test Address",
                Courts = 4,
                ImageUrl = "https://i1.wp.com/harroldtennis.net/wp-content/uploads/2019/04/Bridge-article-Feb-2019-Harrold-tennis-picture.jpg",
                PricePerHour = 22,
                Surface = Surface.Clay,
                Town = Town.Варна,
            };

            await clubsService.CreateAsync(viewModel, userId);

            var clubsCount = dbContext.Clubs.ToArray().Count();

            Assert.Equal(1, clubsCount);
        }

        [Fact]

        public async Task DeleteClubShouldDeleteClub()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "Club_DeleteClub_Database")
                    .Options;
            var dbContext = new ApplicationDbContext(options);
            var clubsService = new ClubsService(new EfRepository<Club>(dbContext));
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser()
            {
                Id = userId,
                UserName = "Test",
            };

            var club = new Club()
            {
                Name = "Test Name",
                Address = "Test Address",
                Courts = 4,
                ImageUrl = "https://i1.wp.com/harroldtennis.net/wp-content/uploads/2019/04/Bridge-article-Feb-2019-Harrold-tennis-picture.jpg",
                PricePerHour = 22,
                Surface = Surface.Clay,
                Town = Town.Варна,
                Id = 1,
                AddedByUser = user,
            };
            dbContext.Clubs.Add(club);
            dbContext.SaveChanges();
            await clubsService.DeleteAsync(1);
            Assert.Equal(0, dbContext.Clubs.Count());

        }

        [Fact]
        public void GetClubByIdShouldReturnClub()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "Club_GetClubById_Database")
                    .Options;
            var dbContext = new ApplicationDbContext(options);
            var clubsService = new ClubsService(new EfRepository<Club>(dbContext));
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser()
            {
                Id = userId,
                UserName = "Test",
            };

            var club = new Club()
            {
                Name = "Test Name",
                Address = "Test Address",
                Courts = 4,
                ImageUrl = "https://i1.wp.com/harroldtennis.net/wp-content/uploads/2019/04/Bridge-article-Feb-2019-Harrold-tennis-picture.jpg",
                PricePerHour = 22,
                Surface = Surface.Clay,
                Town = Town.Варна,
                Id = 1,
                AddedByUser = user,
            };
            dbContext.Clubs.Add(club);
            dbContext.SaveChanges();

            var clubById = clubsService.GetById(club.Id);
            Assert.Equal(club.Name, clubById.Name);
        }

        [Fact]
        public async Task UpdateClubShouldUpdateClub()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                   .UseInMemoryDatabase(databaseName: "Club_Update_Database")
                   .Options;
            var dbContext = new ApplicationDbContext(options);
            var clubsService = new ClubsService(new EfRepository<Club>(dbContext));
            var userId = Guid.NewGuid().ToString();

            var viewModel = new ClubInputModel()
            {
                Name = "Test Name",
                Address = "Test Address",
                Courts = 4,
                ImageUrl = "https://i1.wp.com/harroldtennis.net/wp-content/uploads/2019/04/Bridge-article-Feb-2019-Harrold-tennis-picture.jpg",
                PricePerHour = 22,
                Surface = Surface.Clay,
                Town = Town.Варна,
            };

            await clubsService.CreateAsync(viewModel, userId);

            var editModel = new EditClubInputModel()
            {
                Name = "Test Name Edit",
                Address = "Test Address Edit",
                Courts = 6,
                ImageUrl = "https://i1.wp.com/harroldtennis.net/wp-content/uploads/2019/04/Bridge-article-Feb-2019-Harrold-tennis-picture.jpg",
                PricePerHour = 20,
                Surface = Surface.Clay,
                Town = Town.Варна,
            };

            var club = dbContext.Clubs.Where(x => x.Name == "Test Name").FirstOrDefault();

            await clubsService.UpdateAsync(club.Id, editModel);
            Assert.Equal(editModel.Name, club.Name);
            Assert.Equal(editModel.Address, club.Address);
            Assert.Equal(editModel.Courts, club.Courts);
        }

        [Fact]

        public void GetCountShouldReturnTheCount()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "Club_GetClubCount_Database")
                    .Options;
            var dbContext = new ApplicationDbContext(options);
            var clubsService = new ClubsService(new EfRepository<Club>(dbContext));
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser()
            {
                Id = userId,
                UserName = "Test",
            };
            var clubs = new List<Club>
            {
                new Club
                {
                Name = "Test Name 1",
                Address = "Test Address 1",
                Courts = 4,
                ImageUrl = "https://i1.wp.com/harroldtennis.net/wp-content/uploads/2019/04/Bridge-article-Feb-2019-Harrold-tennis-picture.jpg",
                PricePerHour = 22,
                Surface = Surface.Clay,
                Town = Town.Варна,
                Id = 1,
                AddedByUser = user,
                },
                new Club
                {
                Name = "Test Name 2",
                Address = "Test Address 2",
                Courts = 4,
                ImageUrl = "https://i1.wp.com/harroldtennis.net/wp-content/uploads/2019/04/Bridge-article-Feb-2019-Harrold-tennis-picture.jpg",
                PricePerHour = 22,
                Surface = Surface.Clay,
                Town = Town.Варна,
                Id = 2,
                AddedByUser = user,
                },
            };
            dbContext.Clubs.AddRange(clubs);
            dbContext.SaveChanges();
            var count = clubsService.GetCount();
            Assert.Equal(2, count);
        }

        [Fact]
        public void EditClubByIdShouldReturnClub()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "Club_EditClubById_Database")
                    .Options;
            var dbContext = new ApplicationDbContext(options);
            var clubsService = new ClubsService(new EfRepository<Club>(dbContext));
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser()
            {
                Id = userId,
                UserName = "Test",
            };

            var club = new Club()
            {
                Name = "Test Name",
                Address = "Test Address",
                Courts = 4,
                ImageUrl = "https://i1.wp.com/harroldtennis.net/wp-content/uploads/2019/04/Bridge-article-Feb-2019-Harrold-tennis-picture.jpg",
                PricePerHour = 22,
                Surface = Surface.Clay,
                Town = Town.Варна,
                Id = 1,
                AddedByUser = user,
            };
            dbContext.Clubs.Add(club);
            dbContext.SaveChanges();

            var clubById = clubsService.EditById(club.Id);
            Assert.Equal(club.Name, clubById.Name);
        }

        [Fact]

        public void GetAllShouldReturnAllClubs()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "Club_GetAllClubs_Database")
                    .Options;
            var dbContext = new ApplicationDbContext(options);
            var clubsService = new ClubsService(new EfRepository<Club>(dbContext));
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser()
            {
                Id = userId,
                UserName = "Test",
            };
            var clubs = new List<Club>
            {
                new Club
                {
                Name = "Test Name 1",
                Address = "Test Address 1",
                Courts = 4,
                ImageUrl = "https://i1.wp.com/harroldtennis.net/wp-content/uploads/2019/04/Bridge-article-Feb-2019-Harrold-tennis-picture.jpg",
                PricePerHour = 22,
                Surface = Surface.Clay,
                Town = Town.Варна,
                Id = 1,
                AddedByUser = user,
                },
                new Club
                {
                Name = "Test Name 2",
                Address = "Test Address 2",
                Courts = 4,
                ImageUrl = "https://i1.wp.com/harroldtennis.net/wp-content/uploads/2019/04/Bridge-article-Feb-2019-Harrold-tennis-picture.jpg",
                PricePerHour = 22,
                Surface = Surface.Clay,
                Town = Town.Варна,
                Id = 2,
                AddedByUser = user,
                },
            };
            int page = 1;
            int itemsPerPage = 12;
            dbContext.Clubs.AddRange(clubs);
            dbContext.SaveChanges();
            var count = clubsService.GetAll(page, itemsPerPage).Count();
            Assert.Equal(2, count);
        }
    }
}
