using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaUCH_V1.Models
{
    public class Properties
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string PropertyType { get; set; } = default!;  // Ej: Casa, Apartamento, Estudio

        [Range(1, 100)]
        public int BedroomCount { get; set; }

        [Required]
        [StringLength(300)]
        public string Location { get; set; } = default!;  // Ubicación detallada del inmueble

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }  // Precio del inmueble

        [Range(1, 100)]
        public int BathroomCount { get; set; }  // Número de baños

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Area { get; set; }  // Área en metros cuadrados

        public bool ParkingAvailable { get; set; }  // Disponibilidad de estacionamiento

        [StringLength(1000)]
        public string Description { get; set; } = default!;  // Descripción detallada del inmueble

        public bool HasGarden { get; set; }  // Si tiene jardín

        public bool HasPool { get; set; }  // Si tiene piscina

        public string Status { get; set; } = "Available";  // Estado del inmueble, por ejemplo, 'Available', 'Sold', 'Rented'
    }
}
