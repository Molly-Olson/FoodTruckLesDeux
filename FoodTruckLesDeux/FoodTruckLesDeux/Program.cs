using Microsoft.EntityFrameworkCore;
using FoodTruckLesDeux.Models;

namespace FoodTruckLesDeux
{
    //    // AI declaration !!!!! googled "how do I register DbContext in program.cs" 
    //    // and worked off their generated template
    //    public class FoodTruckDbContext : DbContext
    //    {
    //        public required DbSet<Models.MenuItem> MenuItems { get; set; }
    //        public required DbSet<Models.Location> Locations { get; set; }

    //      
    public class Program
    {
        public static void Main(string[] args)

        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var connectionString =
     builder.Configuration.GetConnectionString("DefaultConnection")
         ?? throw new InvalidOperationException("Connection string"
         + "'DefaultConnection' not found.");

            builder.Services.AddDbContext<FoodTruckContext>(options =>
                options.UseSqlServer(connectionString));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseSqlServer("YourConnectionStringHere");
//        }
//    }

