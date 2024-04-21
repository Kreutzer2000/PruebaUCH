using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaUCH_V1.Models
{
    /// <summary>
    /// Represents a real estate property.
    /// </summary>
    public class Properties
    {
        /// <summary>
        /// Gets or sets the identifier for the property.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the type of property (e.g., House, Apartment, Studio).
        /// </summary>
        [Required]
        [StringLength(100)]
        public string PropertyType { get; set; } = default!;

        /// <summary>
        /// Gets or sets the number of bedrooms in the property.
        /// </summary>
        [Range(1, 100)]
        public int BedroomCount { get; set; }

        /// <summary>
        /// Gets or sets the detailed location of the property.
        /// </summary>
        [Required]
        [StringLength(300)]
        public string Location { get; set; } = default!;

        /// <summary>
        /// Gets or sets the price of the property.
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the number of bathrooms in the property.
        /// </summary>
        [Range(1, 100)]
        public int BathroomCount { get; set; }

        /// <summary>
        /// Gets or sets the area of the property in square meters.
        /// </summary>
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Area { get; set; }

        /// <summary>
        /// Indicates whether parking is available at the property.
        /// </summary>
        public bool ParkingAvailable { get; set; }

        /// <summary>
        /// Gets or sets a detailed description of the property.
        /// </summary>
        [StringLength(1000)]
        public string Description { get; set; } = default!;

        /// <summary>
        /// Indicates whether the property has a garden.
        /// </summary>
        public bool HasGarden { get; set; }

        /// <summary>
        /// Indicates whether the property has a pool.
        /// </summary>
        public bool HasPool { get; set; }

        /// <summary>
        /// Gets or sets the current status of the property (Available, Sold, Rented).
        /// </summary>
        public string Status { get; set; } = "Available"; 
    }
}
