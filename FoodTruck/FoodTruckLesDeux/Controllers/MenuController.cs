using FoodTruckLesDeux.Models;
using Microsoft.AspNetCore.Mvc;
using FoodTruckLesDeux.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace FoodTruckLesDeux.Controllers
{
    public class MenuController : Controller
    {
        private readonly FoodTruckContext _context;
        public MenuController(FoodTruckContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var menuItems = _context.MenuItems.ToList();

            var vm = new MenuListViewModel
            {
                MenuItems = menuItems,
               // **not sure why this line wont work here ** :(
                Title = "Our Delicious Menu",
                TotalCount = menuItems.Count,
                EmptyMessage = "No menu items available at the moment. Please check back later!"
            };
            return View(vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Manage()
        {
            return View();
        }
    }
}


//        }
//        [Route("MenuItems/Info")]
//        public IActionResult Details()
//        {
//            return View();
//        }
//    }
//}
