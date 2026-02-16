using System.ComponentModel.DataAnnotations;

namespace FoodTruckLesDeux.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string ZipCode { get; set; } = "";
    }
}
