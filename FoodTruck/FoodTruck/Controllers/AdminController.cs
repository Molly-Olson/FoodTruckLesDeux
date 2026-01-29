using Microsoft.AspNetCore.Mvc;

namespace FoodTruck.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
