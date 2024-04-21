using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PruebaUCH_V1.Enums;
using PruebaUCH_V1.Utils;

namespace PruebaUCH_V1.Models.DTOs
{
    /// <summary>
    /// DTO for creating a new property.
    /// </summary>
    public class PropertyCreateDTO
    {
        public string PropertyType { get; set; } = default!;
        [Required]
        [StringLength(300)]
        public string Location { get; set; } = default!;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Range(1, 100)]
        public int BedroomCount { get; set; }
        [Range(1, 100)]
        public int BathroomCount { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Area { get; set; }
        public bool ParkingAvailable { get; set; }
        [StringLength(1000)]
        public string Description { get; set; } = default!;
        public bool HasGarden { get; set; }
        public bool HasPool { get; set; }
        [Required]
        [ValidPropertyStatus]
        public string Status { get; set; } = "Available"!;
    }
}
