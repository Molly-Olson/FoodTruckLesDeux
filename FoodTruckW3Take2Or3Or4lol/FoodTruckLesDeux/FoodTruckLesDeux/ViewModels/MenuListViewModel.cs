using System.Collections.Generic;
using FoodTruckLesDeux.Models;

namespace FoodTruckLesDeux.ViewModels
{
    public class MenuListViewModel
    {
        public List<MenuItem> Item { get; set; } = new();
        public string MenuTitle { get; set; } = "Item";
        public string MenuDescription { get; set; } = "";
        public int TotalCount { get; set; }
        public string EmptyMessage { get; set; } = "No menu items currently available. Check back soon!";
    }
}
