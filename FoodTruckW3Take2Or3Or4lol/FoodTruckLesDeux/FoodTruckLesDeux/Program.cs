using FoodTruckLesDeux.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();          
builder.Services.AddDbContext<FoodTruckContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("FoodTruckConnection")));
           

 var app = builder.Build();

//not sure here we go... based off step 7 week 3 demo
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<FoodTruckContext>();

    if (!db.MenuItems.Any())
    {
        db.MenuItems.AddRange(
            new MenuItem
            {
                Name = "Shepheards Pie",
                Description = "Ground Beef made of lentils, walnuts, and mushrooms topped with mixed veggies, mashed potatoes and cheese!",
                Price = 15.00M
            },
             new MenuItem
             {
                 Name = "Shepheards Pie",
                 Description = "Ground Beef made of lentils, walnuts, and mushrooms topped with mixed veggies, mashed potatoes and cheese!",
                 Price = 15.00M
             }
            );
        db.SaveChanges();
    }

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
        
