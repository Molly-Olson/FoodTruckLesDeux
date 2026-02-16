using System.Collections.Generic;
using FoodTruckLesDeux.Models;

namespace FoodTruckLesDeux.ViewModels
{
    public class LocationListViewModel
    {
        public List<Location> Locations { get; set; } = new();
        public string Title { get; set; } = "Our Locations";
        public int TotalCount { get; set; }
        public string EmptyMessage { get; set; } = "No locations available at the moment.";
    }
}
