namespace PlayTennis.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public class ClubSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            //if (dbContext.Clubs.Any())
            //{
            //    return;
            //}

            //var clubs = new Club[]
            //{
            //     new Club
            //     {
            //         Name = "Tennis Club Hispano",
            //         AddedByUserId = "3a130cb9-f147-4449-a588-51eaa49c1ed0",
            //         Address = "Grand Hotel Varna",
            //         Courts = 6,
            //         PricePerHour = 22,
            //         Surface = Surface.Clay,
            //         ImageUrl = "https://gloriapalace.bg/wp-content/uploads/2015/05/teniss-club-sofia-1.jpg",
            //         Town = Town.Варна,
            //         Votes = null,
            //         Reservations = null,
            //     },
            //     new Club
            //     {
            //         Name = "Tennis Club Balchik",
            //         AddedByUserId = "3a130cb9-f147-4449-a588-51eaa49c1ed0",
            //         Address = "Balchik, Hotel Dimyat",
            //         Courts = 12,
            //         PricePerHour = 28,
            //         Surface = Surface.Clay,
            //         ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSlxKiRU7nNBFNJt1Lz4ebrTGL73WEX8EZtJg&usqp=CAU",
            //         Town = Town.Балчик,
            //         Votes = null,
            //         Reservations = null,
            //     },

            //};

            //await dbContext.Clubs.AddRangeAsync(clubs);
        }
    }
}
