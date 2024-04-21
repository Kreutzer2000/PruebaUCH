using System.ComponentModel.DataAnnotations;

namespace PruebaUCH_V1.Utils
{
    /// <summary>
    /// Validation attribute to ensure that the property status is valid.
    /// This attribute checks if the status provided is one of the predefined valid statuses.
    /// </summary>
    public class ValidPropertyStatusAttribute : ValidationAttribute
    {
        /// <summary>
        /// Validates the property status against a predefined set of allowed statuses.
        /// </summary>
        /// <param name="value">The value of the property status to validate.</param>
        /// <param name="validationContext">Provides context about the object being validated including information such as the object instance and metadata about the property being validated.</param>
        /// <returns>
        /// Returns <see cref="ValidationResult.Success"/> if the status is valid, otherwise returns
        /// a <see cref="ValidationResult"/> with an error message specifying the valid options.
        /// </returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var allowedStatuses = new string[] { "Available", "Sold", "Rented" };

            // Check if the value is a valid status
            if (value is string status && allowedStatuses.Contains(status))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"Invalid status. Allowed statuses are: {string.Join(", ", allowedStatuses)}.");
            }
        }
    }
}
