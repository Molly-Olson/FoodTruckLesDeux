using FoodTruckLesDeux.Models;
using Microsoft.EntityFrameworkCore;

using (var context = new FoodTruckContext())
{
    // Use the context here
}

namespace FoodTruckLesDeux.Models
{
    public class FoodTruckContext
    {
        DbSet<MenuItem> MenuItems { get; set; } = null!;
        DbSet<Location> Locations { get; set; } = null!;
    }
}

// AI Declaration!!! googled "how to use DbSet<T> and got public class DbSet<T> where T : class" 
// complier did the rest 
//public class  DbSet<T> where T : class
//{
//    DbSet<MenuItem> MenuItems { get; set; } = null!;
//    DbSet<Location> Locations { get; set; } = null!;
//} colton said not to use this part but now I have new errors so commenting just in case