using FoodTruckLesDeux.Models;
using FoodTruckLesDeux.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodTruckLesDeux.Controllers
{
    public class MenuController : Controller
    {
        private readonly FoodTruckContext _context;
        //compiler added below lines as possible fix for below _context.MenuItem error however it did not fix it
        //public List<MenuItem> item;
        //private object _context;

        public MenuController(FoodTruckContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var menu = _context.MenuItems.ToList();
            var vm = new MenuListViewModel
            {
                Item = menu,
                MenuTitle = "Available Menu Items",
                TotalCount = menu.Count,
                EmptyMessage = "No menu items currently available."

            };

            return View(vm);
        }
    }
}
