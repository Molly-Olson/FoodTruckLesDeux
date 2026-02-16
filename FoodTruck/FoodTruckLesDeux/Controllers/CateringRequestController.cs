using Microsoft.AspNetCore.Mvc;
using FoodTruckLesDeux.Models;

namespace FoodTruckLesDeux.Controllers
{
    public class CateringRequestController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CateringRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return RedirectToAction("Confirmation");
        }
            public IActionResult Confirmation()
            {
                return View();
        }
    }
}
