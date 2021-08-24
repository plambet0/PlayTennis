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
    using PlayTennis.Web.ViewModels.Player;
    using Xunit;

    public class PlayerServiceTests
    {
        [Fact]
        public async Task CreatePlayerShouldCreatePlayer()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "Player_CreatePlayer_Database")
                    .Options;
            var dbContext = new ApplicationDbContext(options);
            var playersService = new PlayersService(
                new EfRepository<Player>(dbContext),
                new EfRepository<Trainer>(dbContext),
                new EfRepository<Club>(dbContext),
                new EfRepository<ApplicationUser>(dbContext),
                new EfRepository<UserClub>(dbContext));
            var userId = Guid.NewGuid().ToString();

            var viewModel = new PlayerInputModel()
            {
                FirstName = "Rafael",
                LastName = "Nadal",
                Email = "rafaelnadal@gmail.com",
                Gender = Gender.Male,
                PhoneNumber = "0888888888",
                Town = Town.Варна,
                Years = 44,
                ImageUrl = "https://i.inews.co.uk/content/uploads/2021/07/SEI_86403193.jpg",
                BackHand = BackHand.OneHanded,
                Hand = Hand.Left,
                PlayFrequencyInHoursPerWeek = 20,
                PlaySinceInYears = 25,
                PreferredSurface = Surface.Clay,
            };

            await playersService.CreateAsync(viewModel, userId);

            var playersCount = dbContext.Players.ToArray().Count();

            Assert.Equal(1, playersCount);
        }

        [Fact]
        public async Task DeletePlayerShouldDeletePlayer()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "Player_DeletePlayer_Database")
                    .Options;
            var dbContext = new ApplicationDbContext(options);
            var playersService = new PlayersService(
                new EfRepository<Player>(dbContext),
                new EfRepository<Trainer>(dbContext),
                new EfRepository<Club>(dbContext),
                new EfRepository<ApplicationUser>(dbContext),
                new EfRepository<UserClub>(dbContext));
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser()
            {
                Id = userId,
                UserName = "Test",
            };

            var player = new Player()
            {
                FirstName = "Rafael",
                LastName = "Nadal",
                Email = "rafaelnadal@gmail.com",
                Gender = Gender.Male,
                PhoneNumber = "0888888888",
                Town = Town.Варна,
                Years = 44,
                ImageUrl = "https://i.inews.co.uk/content/uploads/2021/07/SEI_86403193.jpg",
                BackHand = BackHand.OneHanded,
                Hand = Hand.Left,
                PlayFrequencyInHoursPerWeek = 20,
                PlaySinceInYears = 25,
                PreferredSurface = Surface.Clay,
                Id = 1,
                UserId = userId,
            };
            dbContext.Players.Add(player);
            dbContext.SaveChanges();
            await playersService.DeleteAsync(1);
            Assert.Equal(0, dbContext.Players.Count());
        }

        [Fact]
        public void GetPLayerByIdShouldReturnPlayer()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "Player_GetPlayerById_Database")
                    .Options;
            var dbContext = new ApplicationDbContext(options);
            var playersService = new PlayersService(
                new EfRepository<Player>(dbContext),
                new EfRepository<Trainer>(dbContext),
                new EfRepository<Club>(dbContext),
                new EfRepository<ApplicationUser>(dbContext),
                new EfRepository<UserClub>(dbContext));
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser()
            {
                Id = userId,
                UserName = "Test",
            };

            var player = new Player()
            {
                FirstName = "Rafael",
                LastName = "Nadal",
                Email = "rafaelnadal@gmail.com",
                Gender = Gender.Male,
                PhoneNumber = "0888888888",
                Town = Town.Варна,
                Years = 44,
                ImageUrl = "https://i.inews.co.uk/content/uploads/2021/07/SEI_86403193.jpg",
                BackHand = BackHand.OneHanded,
                Hand = Hand.Left,
                PlayFrequencyInHoursPerWeek = 20,
                PlaySinceInYears = 25,
                PreferredSurface = Surface.Clay,
                Id = 1,
                UserId = userId,
            };
            dbContext.Players.Add(player);
            dbContext.SaveChanges();

            var playerById = playersService.GetById(player.Id);
            Assert.Equal(player.FirstName, playerById.FirstName);
        }

        [Fact]

        public void GetAllShouldReturnAllPlayers()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "Player_GetAllPlayers_Database")
                    .Options;
            var dbContext = new ApplicationDbContext(options);
            var playersService = new PlayersService(
                new EfRepository<Player>(dbContext),
                new EfRepository<Trainer>(dbContext),
                new EfRepository<Club>(dbContext),
                new EfRepository<ApplicationUser>(dbContext),
                new EfRepository<UserClub>(dbContext));
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser()
            {
                Id = userId,
                UserName = "Test",
            };
            var players = new List<Player>
            {
                new Player
                {
                FirstName = "Rafael",
                LastName = "Nadal",
                Email = "rafaelnadal@gmail.com",
                Gender = Gender.Male,
                PhoneNumber = "0888888888",
                Town = Town.Варна,
                Years = 44,
                ImageUrl = "https://i.inews.co.uk/content/uploads/2021/07/SEI_86403193.jpg",
                BackHand = BackHand.OneHanded,
                Hand = Hand.Left,
                PlayFrequencyInHoursPerWeek = 20,
                PlaySinceInYears = 25,
                PreferredSurface = Surface.Clay,
                Id = 1,
                UserId = userId,
                },
                new Player
                {
                FirstName = "Roger",
                LastName = "Federer",
                Email = "rogerfederer@gmail.com",
                Gender = Gender.Male,
                PhoneNumber = "0888888899",
                Town = Town.Варна,
                Years = 44,
                ImageUrl = "https://i.inews.co.uk/content/uploads/2021/07/SEI_86403193.jpg",
                BackHand = BackHand.TwoHanded,
                Hand = Hand.Left,
                PlayFrequencyInHoursPerWeek = 22,
                PlaySinceInYears = 21,
                PreferredSurface = Surface.Hard,
                Id = 2,
                UserId = userId,
                },
            };
            int page = 1;
            int itemsPerPage = 12;
            dbContext.Players.AddRange(players);
            dbContext.SaveChanges();
            var count = playersService.GetAll(page, itemsPerPage).Count();
            Assert.Equal(2, count);
        }

        [Fact]

        public void GetCountShouldReturnTheCountOfPlayers()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "Player_GetPlayersCount_Database")
                    .Options;
            var dbContext = new ApplicationDbContext(options);
            var playersService = new PlayersService(
                new EfRepository<Player>(dbContext),
                new EfRepository<Trainer>(dbContext),
                new EfRepository<Club>(dbContext),
                new EfRepository<ApplicationUser>(dbContext),
                new EfRepository<UserClub>(dbContext));
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser()
            {
                Id = userId,
                UserName = "Test",
            };
            var players = new List<Player>
            {
                new Player
                {
                FirstName = "Rafael",
                LastName = "Nadal",
                Email = "rafaelnadal@gmail.com",
                Gender = Gender.Male,
                PhoneNumber = "0888888888",
                Town = Town.Варна,
                Years = 44,
                ImageUrl = "https://i.inews.co.uk/content/uploads/2021/07/SEI_86403193.jpg",
                BackHand = BackHand.OneHanded,
                Hand = Hand.Left,
                PlayFrequencyInHoursPerWeek = 20,
                PlaySinceInYears = 25,
                PreferredSurface = Surface.Clay,
                Id = 1,
                UserId = userId,
                },
                new Player
                {
                FirstName = "Roger",
                LastName = "Federer",
                Email = "rogerfederer@gmail.com",
                Gender = Gender.Male,
                PhoneNumber = "0888888899",
                Town = Town.Варна,
                Years = 44,
                ImageUrl = "https://i.inews.co.uk/content/uploads/2021/07/SEI_86403193.jpg",
                BackHand = BackHand.TwoHanded,
                Hand = Hand.Left,
                PlayFrequencyInHoursPerWeek = 22,
                PlaySinceInYears = 21,
                PreferredSurface = Surface.Hard,
                Id = 2,
                UserId = userId,
                },
            };
            dbContext.Players.AddRange(players);
            dbContext.SaveChanges();
            var count = playersService.GetCount();
            Assert.Equal(2, count);
        }

        [Fact]

        public void IsRegisteredMethodShouldWorkCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                     .UseInMemoryDatabase(databaseName: "Player_IsRegistered_Database")
                     .Options;
            var dbContext = new ApplicationDbContext(options);
            var playersService = new PlayersService(
                new EfRepository<Player>(dbContext),
                new EfRepository<Trainer>(dbContext),
                new EfRepository<Club>(dbContext),
                new EfRepository<ApplicationUser>(dbContext),
                new EfRepository<UserClub>(dbContext));
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser()
            {
                Id = userId,
                UserName = "Test",
            };

            var player = new Player()
            {
                FirstName = "Rafael",
                LastName = "Nadal",
                Email = "rafaelnadal@gmail.com",
                Gender = Gender.Male,
                PhoneNumber = "0888888888",
                Town = Town.Варна,
                Years = 44,
                ImageUrl = "https://i.inews.co.uk/content/uploads/2021/07/SEI_86403193.jpg",
                BackHand = BackHand.OneHanded,
                Hand = Hand.Left,
                PlayFrequencyInHoursPerWeek = 20,
                PlaySinceInYears = 25,
                PreferredSurface = Surface.Clay,
                Id = 1,
                UserId = userId,
            };
            dbContext.Players.Add(player);
            dbContext.SaveChanges();

            var isRegistered = playersService.IsRegistered(userId);
            Assert.True(isRegistered);
        }

        [Fact]

        public void IsATrainerdMethodShouldWorkCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                     .UseInMemoryDatabase(databaseName: "Player_IsATrainer_Database")
                     .Options;
            var dbContext = new ApplicationDbContext(options);
            var playersService = new PlayersService(
               new EfRepository<Player>(dbContext),
               new EfRepository<Trainer>(dbContext),
               new EfRepository<Club>(dbContext),
               new EfRepository<ApplicationUser>(dbContext),
               new EfRepository<UserClub>(dbContext));
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser()
            {
                Id = userId,
                UserName = "Test",
            };

            var player = new Player()
            {
                FirstName = "Rafael",
                LastName = "Nadal",
                Email = "rafaelnadal@gmail.com",
                Gender = Gender.Male,
                PhoneNumber = "0888888888",
                Town = Town.Варна,
                Years = 44,
                ImageUrl = "https://i.inews.co.uk/content/uploads/2021/07/SEI_86403193.jpg",
                BackHand = BackHand.OneHanded,
                Hand = Hand.Left,
                PlayFrequencyInHoursPerWeek = 20,
                PlaySinceInYears = 25,
                PreferredSurface = Surface.Clay,
                Id = 1,
                UserId = userId,
            };
            dbContext.Players.Add(player);
            dbContext.SaveChanges();

            var isATrainer = playersService.IsATrainer(userId);
            Assert.False(isATrainer);
        }

        [Fact]

        public async Task AddToFavoritesShouldAddClubToPlayerFavoriteClubbs()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                     .UseInMemoryDatabase(databaseName: "Player_AddToFavorites_Database")
                     .Options;
            var dbContext = new ApplicationDbContext(options);
            var playersService = new PlayersService(
               new EfRepository<Player>(dbContext),
               new EfRepository<Trainer>(dbContext),
               new EfRepository<Club>(dbContext),
               new EfRepository<ApplicationUser>(dbContext),
               new EfRepository<UserClub>(dbContext));
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser()
            {
                Id = userId,
                UserName = "Test",
            };

            var player = new Player()
            {
                FirstName = "Rafael",
                LastName = "Nadal",
                Email = "rafaelnadal@gmail.com",
                Gender = Gender.Male,
                PhoneNumber = "0888888888",
                Town = Town.Варна,
                Years = 44,
                ImageUrl = "https://i.inews.co.uk/content/uploads/2021/07/SEI_86403193.jpg",
                BackHand = BackHand.OneHanded,
                Hand = Hand.Left,
                PlayFrequencyInHoursPerWeek = 20,
                PlaySinceInYears = 25,
                PreferredSurface = Surface.Clay,
                Id = 1,
                UserId = userId,
            };
            dbContext.Players.Add(player);
            dbContext.SaveChanges();

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

            await playersService.AddToFavoritesAsync(club.Id, userId);
            var favoriteClubsCount = user.FavoriteClubs.Count();
            Assert.Equal(1, favoriteClubsCount);
        }

        [Fact]

        public async Task DeleteFromFavoritesShouldDeleteClubFromPlayerFavoriteClubbs()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                     .UseInMemoryDatabase(databaseName: "Player_DeleteFromFavorites_Database")
                     .Options;
            var dbContext = new ApplicationDbContext(options);
            var playersService = new PlayersService(
               new EfRepository<Player>(dbContext),
               new EfRepository<Trainer>(dbContext),
               new EfRepository<Club>(dbContext),
               new EfRepository<ApplicationUser>(dbContext),
               new EfRepository<UserClub>(dbContext));
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser()
            {
                Id = userId,
                UserName = "Test",
            };

            var player = new Player()
            {
                FirstName = "Rafael",
                LastName = "Nadal",
                Email = "rafaelnadal@gmail.com",
                Gender = Gender.Male,
                PhoneNumber = "0888888888",
                Town = Town.Варна,
                Years = 44,
                ImageUrl = "https://i.inews.co.uk/content/uploads/2021/07/SEI_86403193.jpg",
                BackHand = BackHand.OneHanded,
                Hand = Hand.Left,
                PlayFrequencyInHoursPerWeek = 20,
                PlaySinceInYears = 25,
                PreferredSurface = Surface.Clay,
                Id = 1,
                UserId = userId,
            };
            dbContext.Players.Add(player);
            dbContext.SaveChanges();

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

            await playersService.DeleteFromFavoritesAsync(club.Id, userId);
            var favoriteClubsCount = user.FavoriteClubs.Count();
            Assert.Equal(0, favoriteClubsCount);
        }
    }
}
