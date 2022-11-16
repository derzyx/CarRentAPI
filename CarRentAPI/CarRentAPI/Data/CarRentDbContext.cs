using CarRentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentAPI.Data
{
    public class CarRentDbContext: DbContext
    {
        public CarRentDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<RentalPlace> RentalPlaces { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
