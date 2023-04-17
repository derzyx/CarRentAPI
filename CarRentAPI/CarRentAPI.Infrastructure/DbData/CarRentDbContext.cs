using CarRentAPI.Domain.Enums;
using CarRentAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace CarRentAPI.Infrastructure.DbData
{
    public class CarRentDbContext: DbContext
    {

        public DbSet<RentalPlace> RentalPlaces { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        //public CarRentDbContext(DbContextOptions<CarRentDbContext> options) : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost\\sqlexpress;Database=CarRentCalcDb;Trusted_Connection=true");
        }

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
                (
                    "Audi",
                    PriceCategories.Premium,
                    13.5f,
                    1,
                    false,
                    1
                ),
                new Car
                (
                    "Renault",
                    PriceCategories.Medium,
                    10.7f,
                    1,
                    false,
                    2
                ),
                new Car
                (
                    "Fiat",
                    PriceCategories.Standard,
                    9.1f,
                    1,
                    false,
                    3
                ),
                new Car
                (
                    "Porshe",
                    PriceCategories.Premium,
                    17.2f,
                    2,
                    false,
                    4
                ),
                new Car
                (
                    "Kia",
                    PriceCategories.Basic,
                    9.7f,
                    2,
                    false,
                    5
                ),
                new Car
                (
                    "Fiat",
                    PriceCategories.Standard,
                    9.1f,
                    2,
                    false,
                    6
                ),
                new Car
                (
                    "Ford",
                    PriceCategories.Medium,
                    11.2f,
                    2,
                    false,
                    7
                )
            );
        }

 
    }
}
