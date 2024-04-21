using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PruebaUCH_V1.Interfaces;
using PruebaUCH_V1.Models.DTOs;

namespace PruebaUCH_V1.Controllers
{
    /// <summary>
    /// Manages properties, allowing for listing, fetching, creating, updating, and deleting properties.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly ILogger<PropertiesController> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertiesController"/>.
        /// </summary>
        /// <param name="propertyRepository">Repository for property data management.</param>
        /// <param name="logger">Logger for logging operation.</param>
        /// <param name="mapper">AutoMapper instance for object mapping.</param>
        public PropertiesController(
            IPropertyRepository propertyRepository,
            ILogger<PropertiesController> logger,
            IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all properties.
        /// </summary>
        /// <returns>A list of properties.</returns>
        // GET: api/Properties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyListDTO>>> GetProperties()
        {
            _logger.LogInformation("Getting all properties");
            var properties = await _propertyRepository.GetAllPropertiesAsync();
            var propertiesDTO = _mapper.Map<IEnumerable<PropertyListDTO>>(properties);
            return Ok(propertiesDTO);
        }

        /// <summary>
        /// Retrieves a specific property by ID.
        /// </summary>
        /// <param name="id">The ID of the property to retrieve.</param>
        /// <returns>The requested property if found; otherwise, NotFound.</returns>
        // GET: api/Properties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyDetailsDTO>> GetProperty(int id)
        {
            _logger.LogInformation($"Getting property with ID {id}");
            var property = await _propertyRepository.GetPropertyByIdAsync(id);
            if (property == null)
            {
                _logger.LogWarning($"Property with ID {id} not found");
                return NotFound();
            }

            var propertyDTO = _mapper.Map<PropertyDetailsDTO>(property);
            return Ok(propertyDTO);
        }

        /// <summary>
        /// Creates a new property.
        /// </summary>
        /// <param name="propertyCreateDTO">The property data to create.</param>
        /// <returns>The created property.</returns>
        // POST: api/Properties
        [HttpPost]
        public async Task<ActionResult<PropertyDetailsDTO>> PostProperty(PropertyCreateDTO propertyCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Post failed. Model state is not valid");
                return BadRequest(ModelState);
            }
            _logger.LogInformation("Posting a new property");
            var property = _mapper.Map<Models.Properties>(propertyCreateDTO);
            var newProperty = await _propertyRepository.CreatePropertyAsync(property);
            var propertyDTO = _mapper.Map<PropertyDetailsDTO>(newProperty);
            return CreatedAtAction(nameof(GetProperty), new { id = newProperty.Id }, propertyDTO);
        }

        /// <summary>
        /// Updates an existing property.
        /// </summary>
        /// <param name="id">The ID of the property to update.</param>
        /// <param name="propertyUpdateDTO">The updated data for the property.</param>
        /// <returns>A result indicating the outcome of the operation.</returns>
        // PUT: api/Properties/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProperty(int id, PropertyUpdateDTO propertyUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Update failed. Model state is not valid");
                return BadRequest(ModelState);
            }
            if (id != propertyUpdateDTO.Id)
            {
                _logger.LogWarning($"Update failed. ID {id} does not match with property ID {propertyUpdateDTO.Id}");
                return BadRequest();
            }
            _logger.LogInformation($"Updating property with ID {id}");
            var property = await _propertyRepository.GetPropertyByIdAsync(id);
            if (property == null)
            {
                _logger.LogWarning($"Property with ID {id} not found");
                return NotFound();
            }
            _mapper.Map(propertyUpdateDTO, property);
            await _propertyRepository.UpdatePropertyAsync(property);
            return NoContent();
        }

        /// <summary>
        /// Deletes a property by its ID.
        /// </summary>
        /// <param name="id">The ID of the property to delete.</param>
        /// <returns>A result indicating the outcome of the operation.</returns>
        // DELETE: api/Properties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var property = await _propertyRepository.GetPropertyByIdAsync(id);
            if (property == null)
            {
                return NotFound($"Property with ID {id} not found");
            }
            _logger.LogInformation($"Deleting property with ID {id}");
            await _propertyRepository.DeletePropertyAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Checks the service status.
        /// </summary>
        /// <returns>An OK result indicating the service is running.</returns>
        // GET: api/Properties/ServiceStatus
        [HttpGet("ServiceStatus")]
        public ActionResult GetServiceStatus()
        {
            _logger.LogInformation("Checking service status");
            return Ok("Service has been successfully started and is running.");
        }

    }
}
