using CarRentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentAPI.Data
{
    public class CarRentDbContext: DbContext
    {
        //public CarRentDbContext(DbContextOptions options) : base(options)
        //{

        //}



        public DbSet<RentalPlace> RentalPlaces { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentalPlace>().HasData(
                new RentalPlace
                {
                    Id = 1,
                    City = "Rzeszow",
                    BasePrice = 230f
                },
                new RentalPlace
                {
                    Id = 2,
                    City = "Poznan",
                    BasePrice = 310f
                }
            );

            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    Name = "Audi",
                    PriceCategory = PriceCategories.Premium,
                    AvgFuelConsumption = 13.5f,
                    RentalPlaceId = 1,
                },
                new Car
                {
                    Id = 2,
                    Name = "Renault",
                    PriceCategory = PriceCategories.Medium,
                    AvgFuelConsumption = 10.7f,
                    RentalPlaceId = 1,
                },
                new Car
                {
                    Id = 3,
                    Name = "Fiat",
                    PriceCategory = PriceCategories.Standard,
                    AvgFuelConsumption = 9.1f,
                    RentalPlaceId = 1,
                },
                new Car
                {
                    Id = 4,
                    Name = "Porshe",
                    PriceCategory = PriceCategories.Premium,
                    AvgFuelConsumption = 17.2f,
                    RentalPlaceId = 2,
                },
                new Car
                {
                    Id = 5,
                    Name = "Kia",
                    PriceCategory = PriceCategories.Basic,
                    AvgFuelConsumption = 9.7f,
                    RentalPlaceId = 2,
                },
                new Car
                {
                    Id = 6,
                    Name = "Fiat",
                    PriceCategory = PriceCategories.Standard,
                    AvgFuelConsumption = 9.1f,
                    RentalPlaceId = 2,
                },
                new Car
                {
                    Id = 7,
                    Name = "Ford",
                    PriceCategory = PriceCategories.Medium,
                    AvgFuelConsumption = 11.2f,
                    RentalPlaceId = 2,
                }
            );
        }
    }
}
