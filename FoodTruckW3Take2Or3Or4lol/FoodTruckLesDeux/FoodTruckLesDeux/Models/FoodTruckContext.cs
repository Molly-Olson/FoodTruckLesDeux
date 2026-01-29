using Microsoft.EntityFrameworkCore;
namespace FoodTruckLesDeux.Models
{
    public class FoodTruckContext : DbContext
    {
        public FoodTruckContext(DbContextOptions<FoodTruckContext> options)
            : base(options)
        {
        }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
