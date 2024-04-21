namespace PruebaUCH_V1.Models.DTOs
{
    /// <summary>
    /// DTO for displaying detailed property information.
    /// </summary>
    public class PropertyDetailsDTO : PropertyListDTO
    {
        public string Description { get; set; } = default!;
        public bool HasGarden { get; set; }
        public bool HasPool { get; set; }
    }
}
