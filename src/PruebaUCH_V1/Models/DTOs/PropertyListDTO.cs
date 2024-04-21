namespace PruebaUCH_V1.Models.DTOs
{
    /// <summary>
    /// DTO for listing properties with basic details.
    /// </summary>
    public class PropertyListDTO
    {
        public int Id { get; set; }
        public string PropertyType { get; set; } = default!;
        public string Location { get; set; } = default!;
        public decimal Price { get; set; }
        public int BedroomCount { get; set; }
        public int BathroomCount { get; set; }
        public decimal Area { get; set; }
        public bool ParkingAvailable { get; set; }
        public string Status { get; set; } = default!;
    }
}
