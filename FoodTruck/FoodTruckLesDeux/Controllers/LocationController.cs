using FoodTruckLesDeux.Models;
using Microsoft.AspNetCore.Mvc;
using FoodTruckLesDeux.ViewModels;

namespace FoodTruckLesDeux.Controllers
{
    public class LocationController : Controller
    {
        private readonly FoodTruckContext _context;
        public LocationController(FoodTruckContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var locations = _context.Locations.ToList();
            
            var vm = new LocationListViewModel
            {
                Locations = locations,
                Title = "Our Locations",
                TotalCount = locations.Count,
                EmptyMessage = "No locations available at the moment. Please check back later!"
            };
            return View(vm);
        }
        //[Route("Locations/Details")]
        //public IActionResult Details()
        //{
        //    return View();
        //}
    }
}
