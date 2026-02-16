using FoodTruckLesDeux.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FoodTruckLesDeux.Models
{
    public class FoodTruckContext : IdentityDbContext
    {
        public FoodTruckContext(DbContextOptions<FoodTruckContext> options)
            : base(options)
        {
        }
        public DbSet<MenuItem> MenuItems => Set<MenuItem>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<FoodTruckLesDeux.Models.CateringRequestModel> CateringRequestModel { get; set; } = default!;
    } }
