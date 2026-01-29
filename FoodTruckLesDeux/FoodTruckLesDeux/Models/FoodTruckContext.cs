using Microsoft.EntityFrameworkCore;
namespace FoodTruckLesDeux.Models { 

    public class FoodTruckContext : DbContext
{ 
        public required DbSet<MenuItem>? MenuItems { get; set; }
        public required DbSet<Location> Locations { get; set; }
        }
    }


