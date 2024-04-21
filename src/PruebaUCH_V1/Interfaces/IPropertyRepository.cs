using PruebaUCH_V1.Models;

namespace PruebaUCH_V1.Interfaces
{
    /// <summary>
    /// Interface defining the operations for managing properties.
    /// </summary>
    public interface IPropertyRepository
    {
        /// <summary>
        /// Retrieves all properties from the database.
        /// </summary>
        /// <returns>A collection of all properties.</returns>
        Task<IEnumerable<Properties>> GetAllPropertiesAsync();

        /// <summary>
        /// Retrieves a single property by its ID.
        /// </summary>
        /// <param name="id">The ID of the property to retrieve.</param>
        /// <returns>The property if found; otherwise, null.</returns>
        Task<Properties> GetPropertyByIdAsync(int id);

        /// <summary>
        /// Creates a new property in the database.
        /// </summary>
        /// <param name="property">The property to create.</param>
        /// <returns>The created property with its new state.</returns>
        Task<Properties> CreatePropertyAsync(Properties property);

        /// <summary>
        /// Updates an existing property in the database.
        /// </summary>
        /// <param name="property">The property to update.</param>
        Task UpdatePropertyAsync(Properties property);

        /// <summary>
        /// Deletes a property from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the property to delete.</param>
        Task DeletePropertyAsync(int id);
    }
}
