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
    using PlayTennis.Web.ViewModels.Reservation;
    using Xunit;

    public class ReservationServiceTests
    {
        [Fact]
        public async Task CreateReservationShouldCreateReservation()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "Reservation_CreateReservation_Database")
                    .Options;
            var dbContext = new ApplicationDbContext(options);
            var playersService = new PlayersService(
                new EfRepository<Player>(dbContext),
                new EfRepository<Trainer>(dbContext),
                new EfRepository<Club>(dbContext),
                new EfRepository<ApplicationUser>(dbContext),
                new EfRepository<UserClub>(dbContext));
            var dateTimeParseService = new DateTimeParseService();
            var reservationsService = new ReservationsService(dateTimeParseService, new EfRepository<Reservation>(dbContext), playersService);
            var userId = Guid.NewGuid().ToString();

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
                AddedByUserId = userId,
            };
            dbContext.Clubs.Add(club);
            dbContext.SaveChanges();

            var viewModel = new ReservationViewModel()
            {
                 ClubId = club.Id,
                 Address = club.Address,
                 Name = club.Name,
                 Town = "Варна",

            };
            var date = DateTime.UtcNow.AddDays(5);
            await reservationsService.CreateAsync(viewModel, userId, date, club.Id);

            var reservationsCount = dbContext.Reservations.ToArray().Count();

            Assert.Equal(1, reservationsCount);
        }

        [Fact]

        public async Task DeleteReservationShouldDeleteReservation()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "Reservation_CreateReservation_Database")
                    .Options;
            var dbContext = new ApplicationDbContext(options);
            var playersService = new PlayersService(
                new EfRepository<Player>(dbContext),
                new EfRepository<Trainer>(dbContext),
                new EfRepository<Club>(dbContext),
                new EfRepository<ApplicationUser>(dbContext),
                new EfRepository<UserClub>(dbContext));
            var dateTimeParseService = new DateTimeParseService();
            var reservationsService = new ReservationsService(dateTimeParseService, new EfRepository<Reservation>(dbContext), playersService);
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
                AddedByUserId = userId,
            };
            dbContext.Clubs.Add(club);
            dbContext.SaveChanges();

            var reservation = new Reservation()
            {
                ClubId = club.Id,
                DateTime = DateTime.UtcNow.AddDays(5),
                Club = club,
                Id = 1,
                User = user,
                UserId = user.Id,
            };
            dbContext.Reservations.Add(reservation);
            dbContext.SaveChanges();
            await reservationsService.DeleteAsync(1);
            Assert.Equal(0, dbContext.Reservations.Count());

        }

        [Fact]
        public void GetReservationByIdShouldReturnReservation()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "Reservation_CreateReservation_Database")
                    .Options;
            var dbContext = new ApplicationDbContext(options);
            var playersService = new PlayersService(
                new EfRepository<Player>(dbContext),
                new EfRepository<Trainer>(dbContext),
                new EfRepository<Club>(dbContext),
                new EfRepository<ApplicationUser>(dbContext),
                new EfRepository<UserClub>(dbContext));
            var dateTimeParseService = new DateTimeParseService();
            var reservationsService = new ReservationsService(dateTimeParseService, new EfRepository<Reservation>(dbContext), playersService);
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
                AddedByUserId = userId,
            };
            dbContext.Clubs.Add(club);
            dbContext.SaveChanges();

            var reservation = new Reservation()
            {
                ClubId = club.Id,
                DateTime = DateTime.UtcNow.AddDays(5),
                Club = club,
                Id = 1,
                User = user,
                UserId = user.Id,
            };
            dbContext.Reservations.Add(reservation);
            dbContext.SaveChanges();
            var reservationById = reservationsService.GetById(reservation.Id);
            Assert.Equal(reservation.Id, reservationById.Id);
        }

        [Fact]

        public void GetAllByIdShouldReturnAllReservationByTheCurrentId()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "Reservation_CreateReservation_Database")
                    .Options;
            var dbContext = new ApplicationDbContext(options);
            var playersService = new PlayersService(
                new EfRepository<Player>(dbContext),
                new EfRepository<Trainer>(dbContext),
                new EfRepository<Club>(dbContext),
                new EfRepository<ApplicationUser>(dbContext),
                new EfRepository<UserClub>(dbContext));
            var dateTimeParseService = new DateTimeParseService();
            var reservationsService = new ReservationsService(dateTimeParseService, new EfRepository<Reservation>(dbContext), playersService);
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
                AddedByUserId = userId,
            };
            dbContext.Clubs.Add(club);

            dbContext.SaveChanges();

            var reservations = new List<Reservation>
            {
                new Reservation
                {
                ClubId = club.Id,
                DateTime = DateTime.UtcNow.AddDays(5),
                Club = club,
                Id = 1,
                User = user,
                UserId = user.Id,
                },
                new Reservation
                {
                ClubId = club.Id,
                DateTime = DateTime.UtcNow.AddDays(6),
                Club = club,
                Id = 2,
                User = user,
                UserId = user.Id,
                },
            };

            dbContext.Reservations.AddRange(reservations);
            dbContext.SaveChanges();
            var count = reservationsService.GetAllById(userId).Count();
            Assert.Equal(2, count);
        }
    }
}
