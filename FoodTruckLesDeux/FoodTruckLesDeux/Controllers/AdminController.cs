using Microsoft.AspNetCore.Mvc;

namespace FoodTruckLesDeux.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }   
    }
}
