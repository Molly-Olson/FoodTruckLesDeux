using Microsoft.AspNetCore.Mvc;

namespace FoodTruck.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
