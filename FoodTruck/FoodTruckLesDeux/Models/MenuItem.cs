using System.ComponentModel.DataAnnotations;

namespace FoodTruckLesDeux.Models
{
    public class MenuItem
    {
        [Key]
        public int MenuItemId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; } = 0.0M;
    }
}
