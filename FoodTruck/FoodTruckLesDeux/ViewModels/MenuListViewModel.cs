using System.Collections.Generic;
using FoodTruckLesDeux.Models;

namespace FoodTruckLesDeux.ViewModels
{
    public class MenuListViewModel
    {
        public List<MenuItem> MenuItems { get; set; } = new();
        public string Title { get; set; } = "Our Menu";
        public int TotalCount { get; set; }
        public string EmptyMessage { get; set; } = "No menu items available at the moment.";
    }
}
