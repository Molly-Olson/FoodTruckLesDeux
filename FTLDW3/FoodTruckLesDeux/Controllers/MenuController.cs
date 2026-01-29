using Microsoft.AspNetCore.Mvc;

namespace FoodTruckLesDeux.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
