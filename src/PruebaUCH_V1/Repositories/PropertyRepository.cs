using Microsoft.EntityFrameworkCore;
using PruebaUCH_V1.Data;
using PruebaUCH_V1.Interfaces;
using PruebaUCH_V1.Models;

namespace PruebaUCH_V1.Repositories
{
    /// <summary>
    /// Repository implementation for managing properties using Entity Framework.
    /// </summary>
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<PropertyRepository> _logger;

        /// <summary>
        /// Initializes a new instance of the PropertyRepository with necessary dependencies.
        /// </summary>
        /// <param name="context">The data context for database operations.</param>
        /// <param name="logger">The logger for logging messages.</param>
        public PropertyRepository(
            DataContext context, 
            ILogger<PropertyRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Properties>> GetAllPropertiesAsync()
        {
            _logger.LogInformation("Retrieving all properties from database");
            return await _context.Properties.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Properties> GetPropertyByIdAsync(int id)
        {
            _logger.LogInformation($"Retrieving property with ID {id}");
            return await _context.Properties.FindAsync(id);
        }

        /// <inheritdoc/>
        public async Task<Properties> CreatePropertyAsync(Properties property)
        {
            _logger.LogInformation("Creating new property");
            _context.Properties.Add(property);
            await _context.SaveChangesAsync();
            return property;
        }

        /// <inheritdoc/>
        public async Task UpdatePropertyAsync(Properties property)
        {
            _logger.LogInformation($"Updating property with ID {property.Id}");
            _context.Entry(property).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeletePropertyAsync(int id)
        {
            _logger.LogInformation($"Deleting property with ID {id}");
            var property = await _context.Properties.FindAsync(id);
            if (property != null)
            {
                _context.Properties.Remove(property);
                await _context.SaveChangesAsync();
            }
        }
    }
}
