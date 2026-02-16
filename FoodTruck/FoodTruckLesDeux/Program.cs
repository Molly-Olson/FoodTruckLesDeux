using FoodTruckLesDeux.Models;
using FoodTruckLesDeux.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace FoodTruckLesDeux
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<FoodTruckContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("FoodTruckLesDeuxConnection")));

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<FoodTruckContext>();

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<FoodTruckContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddTransient<IEmailSender, DevEmailSender>();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<FoodTruckContext>();
                if (!db.MenuItems.Any() && !db.Locations.Any())
                {
                    // Seed initial data compiler built this for me
                    db.MenuItems.AddRange(
                        new MenuItem { Name = "Taco", Price = 3.00M },
                        new MenuItem { Name = "Burrito", Price = 5.00M },
                        new MenuItem { Name = "Quesadilla", Price = 4.00M }
                    );
                    db.Locations.AddRange(
                        new Location { Name = "Downtown", Address = "123 Main St" },
                        new Location { Name = "Uptown", Address = "456 Elm St" }
                    );
                    db.SaveChanges();
                }
            }

                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");
                    app.UseHsts();
                }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            using (var scope = app.Services.CreateScope())
            {
                // -------------------------------------
                // Seed Data for MenuItems
                // -------------------------------------
                var db = scope.ServiceProvider.GetRequiredService<FoodTruckContext>();

                if (!db.MenuItems.Any())
                {
                    db.MenuItems.AddRange(
                        new MenuItem { Name = "Taco", Price = 3.00M },
                        new MenuItem { Name = "Burrito", Price = 5.00M },
                        new MenuItem { Name = "Quesadilla", Price = 4.00M }
                    );
                    db.SaveChanges();
                }
                if (!db.Locations.Any())
                {
                    db.Locations.AddRange(
                        new Location { Name = "Downtown", Address = "123 Main St" },
                        new Location { Name = "Uptown", Address = "456 Elm St" }
                    );
                    db.SaveChanges();
                }

                // -------------------------------------
                // Seed Data for Identity
                // -------------------------------------
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }
                var adminEmail = "admin@FoodTruck.com";
                var adminUser = await userManager.FindByEmailAsync(adminEmail);

                if (adminUser == null)
                {
                    adminUser = new IdentityUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(adminUser, "Admin123!");
                }
                if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            app.Run();
        }
    }
}
