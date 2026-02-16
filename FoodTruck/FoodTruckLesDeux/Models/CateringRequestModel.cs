using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace FoodTruckLesDeux.Models
{
    public class CateringRequestModel
    {
        [Key]
                public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public required string LastName { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public required DateTime EventDate { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Number of guests must be between 1 and 1000.")]
        public required int NumberOfGuests { get; set; }

        //[Required]
        [StringLength(500)]
            public string? SpecialRequests { get; set; }

    }
}
